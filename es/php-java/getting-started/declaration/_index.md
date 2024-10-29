---
title: Declaración
type: docs
weight: 60
url: /es/php-java/declaration/
---

{{% alert color="primary" %}} 

Todos los componentes de Aspose Java requieren un conjunto de permisos de Confianza Total. La razón es que los componentes de Aspose Java necesitan acceder a la configuración del registro, archivos del sistema diferentes del directorio virtual para ciertas operaciones como analizar fuentes, etc. Además, los componentes de Aspose Java se basan en clases del sistema Java básico que también requieren un conjunto de permisos de Confianza Total en muchos casos. 

{{% /alert %}} 

Los proveedores de servicios de Internet que alojan múltiples aplicaciones de diferentes empresas imponen en su mayoría un nivel de seguridad de Confianza Media: 

- OleDbPermission no está disponible. Esto significa que no puedes usar el proveedor de datos OLE DB administrado por ADO.NET para acceder a bases de datos.
- EventLogPermission no está disponible. Esto significa que no puedes acceder al registro de eventos de Windows.
- ReflectionPermission no está disponible. Esto significa que no puedes usar reflexión.
- RegistryPermission no está disponible. Esto significa que no puedes acceder al registro.
- WebPermission está restringido. Esto significa que tu aplicación solo puede comunicarse con una dirección o rango de direcciones que defines en el elemento <trust>.
- FileIOPermission está restringido. Esto significa que solo puedes acceder a archivos en la jerarquía de directorios virtuales de tu aplicación.

{{% alert color="primary" %}} 

Debido a las razones especificadas anteriormente, los componentes de Aspose Java no pueden ser utilizados en servidores que otorgan un conjunto de permisos diferente a Confianza Total. 

{{% /alert %}}