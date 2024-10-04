---
title: Convertir OpenOffice ODP
type: docs
weight: 10
url: /net/convert-openoffice-odp/
keywords: "Convertir ODP a PDF, ODP a PPT, ODP a PPTX, ODP a XPS, ODP a HTML, ODP a TIFF"
description: "Convertir ODP a PDF, ODP a PPT, ODP a PPTX, ODP a HTML y otros formatos con Aspose.Slides."
---

[**Aspose.Slides API**](https://products.aspose.com/slides/net/) te permite convertir presentaciones OpenOffice ODP a muchos formatos. La API utilizada para convertir archivos ODP a otros formatos de documento es la misma utilizada para las operaciones de conversión de PowerPoint (PPT y PPTX). 

Estos ejemplos te muestran cómo convertir documentos ODP a otros formatos (solo cambia el archivo ODP fuente):

- [Convertir ODP a HTML](/slides/net/convert-powerpoint-ppt-and-pptx-to-html/)
- [Convertir ODP a PDF](/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf/)
- [Convertir ODP a TIFF](/slides/net/convert-powerpoint-to-tiff/)
- [Convertir ODP a SWF Flash](/slides/net/convert-powerpoint-ppt-and-pptx-to-swf-flash/)
- [Convertir ODP a XPS](/slides/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/)
- [Convertir ODP a PDF con notas](/slides/net/convert-powerpoint-ppt-and-pptx-to-pdf-with-notes/)
- [Convertir ODP a TIFF con notas](/slides/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/)

Por ejemplo, si necesitas convertir una presentación ODP a PDF, se puede hacer de esta manera:

```csharp
using (Presentation pres = new Presentation("pres.odp"))
{
    pres.Save("pres.pdf", SaveFormat.Pdf);
}
```



## Presentación OpenDocument en diferentes aplicaciones

Cuando se abre un archivo de Presentación OpenDocument en PowerPoint, puede carecer del formato que tenía en la aplicación original donde se creó, porque la aplicación de Presentación OpenDocument y la aplicación de PowerPoint proporcionan diferentes características y opciones.

Estas son algunas de las diferencias:
- En PowerPoint, todas las tablas suelen cargarse al final y superponen otras formas (independientemente de la disposición de las formas en la diapositiva ODP). 
- El relleno de imagen para tablas ODP no es compatible en PowerPoint. 
- La rotación vertical del texto (270, apilado) y la alineación distribuida no son compatibles en LibreOffice/OpenOffice Impress.
- El relleno de imagen, el relleno de degradado y el relleno de patrón para texto no son compatibles en LibreOffice/OpenOffice Impress.

MS PowerPoint y LibreOffice/OpenOffice Impress manejan las listas de manera diferente también. Un archivo ODP creado en PowerPoint no se abrirá correctamente en LibreOffice/OpenOffice y viceversa. 

Esta imagen muestra la vista de la lista creada en LibreOffice Impress:

![odp-list-example](odp-list-example.png)



**Aspose.Slides** guarda las listas ODP para garantizar que se muestren correctamente en LibreOffice/OpenOffice Impress.

[Aprende más sobre el Formato OpenDocument y PowerPoint](https://support.microsoft.com/en-gb/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0/).