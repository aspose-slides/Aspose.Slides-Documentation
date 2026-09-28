---
title: Licencia Aspose.Slides for Reporting Services
type: docs
weight: 70
url: /es/reportingservices/license-aspose-slides-for-reporting-services/
keywords:
- licencia
- licenciamiento
- marca de agua de evaluación
- licencia temporal
- Aspose.Slides for Reporting Services
description: "Aplicar una licencia a Aspose.Slides for Reporting Services copiando el archivo de licencia al servidor de informes y comprobar que las presentaciones exportadas ya no llevan la marca de agua de evaluación."
---
## **Soporte de Licencia**

La versión de evaluación de Aspose.Slides for Reporting Services es el mismo paquete que la adquirida, desde [su página de descarga](https://releases.aspose.com/slides/es/reportingservices/), y ofrece la misma funcionalidad. Sin una licencia, funciona en modo de evaluación e inserta una marca de agua de evaluación en las presentaciones exportadas.

La versión de evaluación se licencia cuando copia un archivo de licencia al servidor de informes. No se requiere código.

Cuando esté satisfecho con su evaluación, puede [adquirir una licencia](https://purchase.aspose.com/pricing/slides/es/reporting-services/). Le recomendamos que revise los diferentes tipos de suscripción. Si tiene preguntas, contacte al equipo de ventas de Aspose.

## **Licenciamiento en Aspose.Slides for Reporting Services**

* La licencia es un archivo XML de texto plano que contiene detalles como el nombre del producto, el número de desarrolladores a los que está licenciada, la fecha de expiración de la suscripción, etc.
* El archivo de licencia está firmado digitalmente, por lo que no debe modificarlo. Incluso la adición accidental de un salto de línea extra al contenido del archivo lo invalidará.

Para aplicar la licencia:

1. Copie el archivo de licencia a la carpeta *ReportServer\bin* de cada instancia del servidor de informes, donde está instalado *Aspose.Slides.ReportingServices.dll* — por ejemplo, *C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer\bin*. [Instalar manualmente](/slides/es/reportingservices/install-manually/#find-the-report-server-folder) enumera las carpetas predeterminadas.
1. Asegúrese de que el archivo tenga uno de los nombres que la extensión busca: *Aspose.Slides.ReportingServices.lic*, *Aspose.Slides.Reporting.Services.lic*, *Aspose.Slides.Product.Family.lic*, *Aspose.Total.ReportingServices.lic*, *Aspose.Total.Reporting.Services.lic*, *Aspose.Total.Product.Family.lic* o *Aspose.Total.lic*.
1. Exportar cualquier informe como una presentación. Si no contiene una marca de agua, la licencia está activa.

La extensión también busca el archivo de licencia en *%ProgramData%\Aspose\Slides* (normalmente *C:\ProgramData\Aspose\Slides*), por lo que una copia allí sirve a todas las instancias en la máquina.

**Modo con Licencia**

Cuando se encuentra un archivo de licencia válido, las presentaciones exportadas no incluyen marca de agua de evaluación.

![Un informe exportado con una licencia: sin marca de agua de evaluación](license-aspose-slides-for-reporting-services_2.png)

**Modo de Evaluación**

Sin una licencia, Aspose.Slides for Reporting Services inserta una marca de agua de evaluación en las presentaciones exportadas.

![Un informe exportado en modo de evaluación, con la marca de agua de evaluación](license-aspose-slides-for-reporting-services_1.png)

{{% alert color="info" title="Note" %}}
Para probar Aspose.Slides for Reporting Services sin limitaciones, puede solicitar una **Licencia Temporal de 30 Días**. Consulte la página [Cómo obtener una licencia temporal](https://purchase.aspose.com/temporary-license) para obtener más información.
{{% /alert %}}