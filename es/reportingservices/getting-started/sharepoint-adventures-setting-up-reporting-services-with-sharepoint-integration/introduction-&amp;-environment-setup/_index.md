---
title: Introducción y Configuración del Entorno
type: docs
weight: 10
url: /es/reportingservices/introduction-&amp;-environment-setup/
---

{{% alert color="primary" %}} 

Ha habido consultas en el pasado sobre la integración de Aspose.Slides para Reporting Services con SharePoint. En este artículo, nos centraremos en SharePoint 2010. Se asume que ya tienes un entorno de granja de SharePoint configurado. Los ejemplos que seguiremos en este artículo serán de un SharePoint Cloud completo, pero los pasos serán similares para un servidor de SharePoint Foundation. Antes de proceder, comencemos con algunos documentos clave que puedes usar como referencia cuando hagas esto: 

- [Descripción general de la integración de Reporting Services y la tecnología de SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [Configuración de Reporting Services para la integración con SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Configuración del Entorno**
La configuración que tendremos consiste en **4 servidores**. Eso incluye un **Controlador de Dominio**, un **Servidor SQL**, un **Servidor SharePoint** y un servidor para **Reporting Services**. Puedes optar por tener SharePoint y Reporting Services en la misma máquina.