---
title: Security
type: docs
weight: 160
url: /net/security/
keywords:
- security
- dependencies
- third-party components
- NuGet
- vulnerability scanning
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Review how Aspose.Slides for .NET processes presentations, which NuGet packages it depends on for each target framework, and which third-party components it includes."
---

## **Security in Aspose.Slides**

Aspose applies best practices when developing its products.

* Aspose.Slides for .NET is used to manipulate presentations and to convert them to other formats. It does not run scripts in presentations. Aspose.Slides parses the presentation structure and lets the end user's code manipulate the object model in a convenient way.
* Aspose.Slides functions as a library that parses and interprets documents without executing remote code. All Aspose products run on your machines. They do not transmit any data to Aspose. The only exception is a [metered license](https://purchase.aspose.com/faqs/licensing/metered): if you use one, only your API usage information is processed.
* Aspose components run in the same user context as regular applications. Therefore, Aspose components do not pose a risk to vital system resources. Furthermore, when an Aspose component opens a document, macros are not run automatically.
* The risks inherent in or associated with the Microsoft Office package do not apply to Aspose components, so Aspose products are very secure.

## **NuGet Dependencies**

Aspose.Slides for .NET depends on packages that Microsoft publishes on NuGet. The dependencies differ by package and target framework:

| Package | Target framework | Dependencies |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

The **Dependencies** section of the [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) and [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) pages on NuGet lists the minimum version of each dependency for every release.

When you add Aspose.Slides to a project, NuGet also restores the dependencies of these packages. To list every package that your project restores, including these transitive dependencies, run this command in the project folder:

```bash
dotnet list package --include-transitive
```

To check the same set of packages against known vulnerabilities, run:

```bash
dotnet list package --vulnerable --include-transitive
```

For other ways to audit NuGet packages, see [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Third-Party Components**

Aspose.Slides includes code from third-party open-source components. They are part of the product, not separate NuGet packages, so tools that read only NuGet dependencies do not list them. Both packages contain the file *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, which lists the components and their licenses:

| Component | License stated in the notice |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **FAQ**

**What systems are used to monitor for vulnerabilities in Aspose code?**

We run a static code analysis for every Aspose.Slides release. We can provide security reports that prove Aspose.Slides code passes OWASP Top 10.

**Does Aspose.Slides use external packages?**

Yes. It depends on the Microsoft NuGet packages listed in [NuGet Dependencies](#nuget-dependencies), and it includes the third-party components listed in [Third-Party Components](#third-party-components). Include both in your security review, and use `dotnet list package --vulnerable --include-transitive` to check the NuGet packages that your project restores.
