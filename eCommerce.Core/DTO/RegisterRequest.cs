using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.DTO;

public record RegisterRequest(
    string? PersonName,
    string? Email,
    string? Password,
    GenderOptions Gender);
