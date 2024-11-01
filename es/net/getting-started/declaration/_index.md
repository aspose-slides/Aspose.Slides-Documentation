---
title: Declaración
type: docs
weight: 110
url: /es/net/declaration/
---

{{% alert color="primary" %}} 

Todos los componentes de Aspose .NET requieren el conjunto de permisos de Confianza Total porque a veces tienen que acceder a configuraciones del registro, archivos del sistema y archivos almacenados en otras ubicaciones (además del directorio virtual) para ciertas operaciones (por ejemplo, análisis de fuentes). Además, los componentes de Aspose .NET se basan en clases del sistema .NET básicas, que requieren el conjunto de permisos de Confianza Total en muchos casos. 

{{% /alert %}} 

Los Proveedores de Servicios de Internet, que alojan múltiples aplicaciones de diferentes empresas, en su mayoría imponen el nivel de seguridad de Confianza Media. En un caso de .NET 2.0, dicho nivel de seguridad aplica estas restricciones: 

- OleDbPermission no está disponible. Esto significa que no puedes utilizar el proveedor de datos OLE DB administrado de ADO.NET para acceder a bases de datos.
- EventLogPermission no está disponible. Esto significa que no puedes acceder al registro de eventos de Windows.
- ReflectionPermission no está disponible. Esto significa que no puedes usar reflexión.
- RegistryPermission no está disponible. Esto significa que no puedes acceder al registro.
- WebPermission es restringido. Esto significa que tu aplicación solo puede comunicarse con una dirección o el rango de direcciones que definiste en el elemento <trust>.
- FileIOPermission es restringido. Esto significa que solo puedes acceder a archivos en la jerarquía del directorio virtual de tu aplicación.

{{% alert color="primary" %}} 

Debido a las razones anteriores, los componentes de Aspose .NET solo pueden ser utilizados en servidores que otorguen el conjunto de permisos de Confianza Total. 

{{% /alert %}}