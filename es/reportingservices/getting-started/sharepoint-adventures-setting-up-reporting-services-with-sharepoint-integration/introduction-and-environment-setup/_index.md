---
title: Introducción y Configuración del Entorno
type: docs
weight: 10
url: /es/reportingservices/introduction-and-environment-setup/
---

{{% alert color="primary" %}} 

Ha habido consultas en el pasado sobre la integración de Aspose.Slides para Reporting Services con SharePoint. En este artículo, nos centraremos en SharePoint 2010. Se asume que ya se tiene configurado un entorno de granja de SharePoint. Los ejemplos que seguiremos en este artículo se basarán en un SharePoint Cloud completo, pero los pasos serán similares para un servidor de SharePoint Foundation. Antes de continuar, comencemos con algunos documentos clave que puedes usar como referencia al hacer esto: 

- [Resumen de la Integración de Tecnología de Reporting Services y SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [Configuración de Reporting Services para la Integración con SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Configuración del Entorno**
La configuración que tendremos consta de **4 servidores**. Esto incluye un **Controlador de Dominio**, un **Servidor SQL**, un **Servidor SharePoint** y un servidor para **Reporting Services**. Puedes optar por tener SharePoint y Reporting Services en la misma máquina.