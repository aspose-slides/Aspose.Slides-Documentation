---
title: Declaración
type: docs
weight: 60
url: /es/java/declaration/
---

{{% alert color="primary" %}} 

Todos los componentes de Aspose Java requieren un conjunto de permisos de Confianza Total. La razón es que los componentes de Aspose Java necesitan acceder a la configuración del registro, archivos del sistema además del directorio virtual para ciertas operaciones como el análisis de fuentes, etc. Además, los componentes de Aspose Java se basan en clases del sistema Java central que también requieren un conjunto de permisos de Confianza Total en muchos casos. 

{{% /alert %}} 

Los Proveedores de Servicios de Internet que alojan múltiples aplicaciones de diferentes empresas en su mayoría imponen un nivel de seguridad de Confianza Media: 

- OleDbPermission no está disponible. Esto significa que no puede usar el proveedor de datos OLE DB administrado de ADO.NET para acceder a bases de datos.
- EventLogPermission no está disponible. Esto significa que no puede acceder al registro de eventos de Windows.
- ReflectionPermission no está disponible. Esto significa que no puede usar reflexión.
- RegistryPermission no está disponible. Esto significa que no puede acceder al registro.
- WebPermission está restringido. Esto significa que su aplicación solo puede comunicarse con una dirección o rango de direcciones que defina en el elemento <trust>.
- FileIOPermission está restringido. Esto significa que solo puede acceder a archivos en la jerarquía del directorio virtual de su aplicación.

{{% alert color="primary" %}} 

Debido a las razones especificadas anteriormente, los componentes de Aspose Java no se pueden utilizar en servidores que otorguen un conjunto de permisos distinto a la Confianza Total. 

{{% /alert %}}