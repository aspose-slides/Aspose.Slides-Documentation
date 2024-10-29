---
title: Preguntas Frecuentes
type: docs
weight: 110
url: /es/reportingservices/frequently-asked-questions/
---

{{% alert color="primary" %}} 

Esta página recopila una serie de preguntas frecuentes sobre:

- [Formatos de archivo soportados](#Supported-File-Formats).
- [Soporte para los servicios de informes de Power BI](#Support-for-Power-BI-Reporting-services).
- [Instalación](#Installation).
- [Configuración de Exportación](#Export-Configuration).

{{% /alert %}} 
### **Formatos de Archivo Soportados**
#### **P: ¿A qué formatos puedes exportar informes usando Aspose.Slides para Reporting Services?**
**R**: Aspose.Slides para Reporting Services permite exportar cualquier informe en formato PPT, PPS, PPTX, PPSX, XPS o RPL.
### **Soporte para los Servicios de Informes de Power BI**
#### **P: ¿Aspose.Slides para Reporting Services soporta Power BI?**
**R**: Sí. Aspose.Slides para Reporting Services soporta la exportación de informes paginados (RDL) en Power BI.
### **Instalación**
#### **P: El programa de instalación no inicia. La instalación manual no conduce al resultado deseado.**
**R**: Asegúrate de que .NET Framework 3.5 esté instalado en tu sistema.
#### **P: Opciones de exportación faltantes tras la instalación de Aspose.Slides para Reporting Services.**
**R**: Si algún CodeGroup en rssrvpolicy.config no funciona correctamente, el analizador del archivo de configuración puede omitir las últimas secciones del grupo. Por lo tanto, mueve todos los CodeGroups asociados con Aspose.Slides para Reporting Services a la parte superior del bloque que contiene los CodeGroups de Aspose.Slides para Reporting Services.
#### **P: No se pudo cargar el archivo o ensamblado Aspose.Slides.ReportingServices (No se puede adquirir permiso de ejecución \ Excepción de HRESULT: 0x80131418).**
**R**: El código de error (0x80131418) indica que el módulo dll no tiene suficientes derechos. Esto puede deberse a una característica de seguridad que bloqueó el acceso completo al archivo .dll si se obtuvo de otra computadora. Esto se puede solucionar abriendo la ventana de propiedades del archivo dll y haciendo clic en el botón "Desbloquear" en el panel "Seguridad".
#### **P: No se puede encontrar la licencia 'Aspose.Slides.Reporting.Services.lic'.**
**R**: El archivo de licencia debe estar ubicado junto al dll o en el directorio Program Files(x86)\Aspose\Slides\.
### **Configuración de Exportación**
#### **P: ¿Cómo puedo cambiar el color de los hipervínculos en un informe exportado?**
**R**: Cada extensión de renderizado de Aspose.Slides para Reporting Services en rsreportserver.config tiene su propia configuración. Para cambiar el color del hipervínculo, establece el valor requerido en la sección <HyperlinkColor>.
#### **P: En las presentaciones exportadas, el texto en las tablas está estirado verticalmente.**
**R**: Esto se hace para facilitar la lectura del documento. Para mostrar el texto en la tabla tal como aparece en el informe, establece la extensión requerida de Aspose.Slides para Reporting Services en "Normal" en el archivo de configuración rsreportserver.config.