---
title: Requisitos de Instalación
type: docs
weight: 20
url: /es/reportingservices/installation-prerequisites/
---

{{% alert color="primary" %}} 

Los siguientes requisitos deben cumplirse antes de proceder con la instalación. 

{{% /alert %}} 
## **Complemento de Reporting Services para SharePoint**
El **Complemento de Reporting Services para SharePoint** es uno de los componentes clave para que la integración funcione adecuadamente. El complemento debe estar instalado en cualquiera de los **Web Front Ends (WFE)** que estén en tu granja de SharePoint junto con el servidor de administración central. Uno de los nuevos cambios con SQL 2008 R2 y SharePoint 2010 es que el complemento 2008 R2 es ahora un requisito previo para la instalación de SharePoint. Esto significa que el complemento de RS se instalará cuando vayas a instalar SharePoint. Se ha mostrado y destacado en la figura a continuación. Esto evita muchos problemas que vimos con SP 2007 y RS 2008 al instalar el complemento. 

![todo:image_alt_text](installation-prerequisites_1.png)

**Figura 1**: Complemento de Reporting Services para SharePoint 
## **Autenticación de SharePoint**
Antes de entrar en las partes de integración de RS, hay una cosa importante que debe ser atendida: cómo configuras tu **Sitio** en la Granja de SharePoint. Más específicamente, cómo configuras la autenticación para el sitio; ya sea que utilice **Clásica** o **Claims**. Esta elección es importante al principio. No creo que puedas cambiar esta opción una vez que se haya hecho. Si puedes cambiarla, no sería un proceso simple. 

{{% alert color="primary" %}} 

Reporting Services 2008 R2 NO es compatible con Claims 

{{% /alert %}} 

Incluso si eliges que tu sitio de SharePoint use **Claims**, Reporting Services en sí no es compatible con Claims. Esto afecta la forma en que funciona la autenticación con Reporting Services. Entonces, ¿cuál es la diferencia desde la perspectiva de Reporting Services? Se reduce a si deseas transmitir las Credenciales de Usuario al origen de datos. 

***Clásica***   - Se puede utilizar Kerberos y transmitir las credenciales del usuario a tu origen de datos de backend (necesitarás usar Kerberos para eso).

***Claims*** ** - Se utiliza un token de Claims y no un token de Windows. RS siempre utilizará Autenticación de Confianza en este escenario y solo tendrá acceso al token de SPUser. Necesitarás almacenar tus credenciales dentro de tu origen de datos. 

Por ahora, solo queremos centrarnos en la configuración de RS. En este punto, SharePoint está instalado en la Caja de SharePoint y configurado con un **Sitio de Autenticación Clásica** en el **puerto 80**. Además, en el servidor de RS he **instalado Reporting Services** y eso es todo.