---
title: Declaración
type: docs
weight: 110
url: /es/net/declaration/
keywords:
- declaración
- componentes
- permiso Full Trust
- configuración del registro
- archivos del sistema
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda sobre los requisitos de confianza, permisos y limitaciones de alojamiento de Aspose.Slides para .NET, para que pueda implementar de forma segura aplicaciones que procesen PPT, PPTX y ODP en servidores."
---
{{% alert color="info" %}} 

Todos los componentes Aspose .NET requieren el conjunto de permisos Full Trust porque a veces deben acceder a la configuración del registro, a archivos del sistema y a archivos almacenados en otras ubicaciones (además del directorio virtual) para ciertas operaciones (por ejemplo, el análisis de fuentes). Además, los Componentes Aspose .NET se basan en clases del núcleo del sistema .NET, que en muchos casos requieren el conjunto de permisos Full Trust. 

{{% /alert %}} 

Los proveedores de servicios de Internet, que alojan múltiples aplicaciones de diferentes empresas, normalmente aplican el nivel de seguridad Medium Trust. En un caso de .NET 2.0, dicho nivel de seguridad impone estas limitaciones: 

- OleDbPermission no está disponible. Esto significa que no puede utilizar el proveedor de datos OLE DB gestionado de ADO.NET para acceder a bases de datos.
- EventLogPermission no está disponible. Esto significa que no puede acceder al registro de eventos de Windows.
- ReflectionPermission no está disponible. Esto significa que no puede usar reflexión.
- RegistryPermission no está disponible. Esto significa que no puede acceder al registro.
- WebPermission está restringido. Esto significa que su aplicación solo puede comunicarse con una dirección o el rango de direcciones que haya definido en el elemento <trust>.
- FileIOPermission está restringido. Esto significa que solo puede acceder a archivos dentro de la jerarquía del directorio virtual de su aplicación.

{{% alert color="info" %}} 

Debido a los motivos anteriores, los componentes Aspose .NET solo pueden usarse en servidores que otorguen el conjunto de permisos Full Trust. 

{{% /alert %}}