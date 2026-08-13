---
title: Declaración
type: docs
weight: 60
url: /es/java/declaration/
keywords:
- declaración
- componentes
- permiso Full Trust
- configuración del registro
- archivos del sistema
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aprenda sobre los requisitos de confianza, permisos y limitaciones de alojamiento de Aspose.Slides para Java, para que pueda implementar de forma segura aplicaciones que procesen PPT, PPTX y ODP en servidores."
---
{{% alert color="info" %}} 

Todos los componentes Aspose Java requieren el conjunto de permisos Full Trust. La razón es que los componentes Aspose Java necesitan acceder a la configuración del registro, a archivos del sistema fuera del directorio virtual para ciertas operaciones como el análisis de fuentes, etc. Además, los componentes Aspose Java se basan en clases centrales del sistema Java que también requieren el conjunto de permisos Full Trust en muchos casos. 

{{% /alert %}} 

Los proveedores de servicios de Internet que alojan múltiples aplicaciones de diferentes empresas suelen aplicar el nivel de seguridad Medium Trust: 

- OleDbPermission no está disponible. Esto significa que no puede usar el proveedor de datos OLE DB gestionado de ADO.NET para acceder a bases de datos.
- EventLogPermission no está disponible. Esto significa que no puede acceder al registro de eventos de Windows.
- ReflectionPermission no está disponible. Esto significa que no puede usar la reflexión.
- RegistryPermission no está disponible. Esto significa que no puede acceder al registro.
- WebPermission está restringido. Esto significa que su aplicación solo puede comunicarse con una dirección o rango de direcciones que defina en el elemento <trust>.
- FileIOPermission está restringido. Esto significa que solo puede acceder a archivos en la jerarquía de directorios virtuales de su aplicación.

{{% alert color="info" %}} 

Debido a las razones especificadas anteriormente, los componentes Aspose Java no pueden usarse en servidores que otorguen un conjunto de permisos distinto de Full Trust. 

{{% /alert %}}