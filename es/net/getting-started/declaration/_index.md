---
title: Requisitos de nivel de confianza
type: docs
weight: 190
url: /es/net/declaration/
keywords:
- nivel de confianza
- permiso de confianza total
- confianza parcial
- confianza media
- seguridad de acceso al código
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Qué nivel de confianza de seguridad de acceso al código necesita Aspose.Slides for .NET: plena confianza en .NET Framework, y sin configuración de confianza en .NET 6 y posteriores."
---
## **Visión general**

Los niveles de confianza de Code Access Security (CAS) existen solo en .NET Framework. Este artículo explica qué significan para Aspose.Slides for .NET: la biblioteca necesita plena confianza en .NET Framework, y en .NET 6 y versiones posteriores no hay ningún nivel de confianza que configurar.

## **.NET Framework**

Aspose.Slides requiere plena confianza en .NET Framework. No se ejecuta bajo confianza parcial, como una aplicación ASP.NET configurada para Medium Trust (`<trust level="Medium" />`): crear un objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) falla con una `SecurityException`.

Microsoft ya no trata la confianza parcial de ASP.NET como una forma de aislar aplicaciones entre sí, y recomienda ejecutar las aplicaciones en grupos de aplicaciones separados. Consulte [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 and Later**

Code Access Security no está disponible en .NET 6 y versiones posteriores, por lo que no hay ningún nivel de confianza que otorgar. Aspose.Slides se ejecuta con los permisos de la cuenta que ejecuta su aplicación. Para restringir lo que una aplicación puede acceder, Microsoft recomienda límites del sistema operativo, como cuentas de usuario, contenedores o máquinas virtuales. Consulte [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **Preguntas frecuentes**

**¿Puedo usar Aspose.Slides con un proveedor de hosting que ejecuta aplicaciones ASP.NET en Medium Trust?**

No en Medium Trust. En .NET Framework, la aplicación que utiliza Aspose.Slides debe ejecutarse con plena confianza.