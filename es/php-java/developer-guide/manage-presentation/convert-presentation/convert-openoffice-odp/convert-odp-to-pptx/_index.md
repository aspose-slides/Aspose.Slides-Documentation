---
title: Convertir ODP a PPTX en PHP
linktitle: ODP a PPTX
type: docs
weight: 10
url: /es/php-java/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir presentación
- convertir diapositiva
- convertir ODP
- OpenDocument a PPTX
- ODP a PPTX
- guardar ODP como PPTX
- exportar ODP a PPTX
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Convertir ODP a PPTX con Aspose.Slides para PHP via Java. Ejemplos de código limpios, consejos por lotes y resultados de alta calidad—no se necesita PowerPoint."
---

## **Convertir ODP a Presentación PPTX/PPT**
Aspose.Slides for PHP via Java ofrece la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) que representa un archivo de presentación. La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) ahora también puede acceder a ODP mediante el constructor [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) cuando se instancia el objeto. El ejemplo siguiente muestra cómo convertir una presentación ODP en una presentación PPTX.
```php
// Abrir el archivo ODP
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Guardar la presentación ODP en formato PPTX
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **Ejemplo en Vivo**
Puedes visitar la aplicación web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) que está construida con **Aspose.Slides API**. La aplicación demuestra cómo se puede implementar la conversión de ODP a PPTX con Aspose.Slides API.

## **Preguntas frecuentes**

**¿Necesito instalar Microsoft PowerPoint o LibreOffice para convertir ODP a PPTX?**

No. Aspose.Slides funciona de forma independiente y no requiere aplicaciones de terceros para leer o escribir ODP/PPTX.

**¿Se conservan las diapositivas maestras, los diseños y los temas durante la conversión?**

Sí. La biblioteca utiliza un modelo de objeto de presentación completo y conserva la estructura, incluidas las diapositivas maestras y los diseños, de modo que el diseño permanece correcto después de la conversión.

**¿Puedo convertir archivos ODP protegidos con contraseña?**

Sí. Aspose.Slides permite detectar la protección, abrir y trabajar con [presentaciones protegidas](/slides/es/php-java/password-protected-presentation/) (incluido ODP) cuando se proporciona la contraseña, así como configurar el cifrado y el acceso a las propiedades del documento.

**¿Es Aspose.Slides adecuado para servicios de conversión en la nube o basados en REST?**

Sí. Puedes usar la biblioteca local en tu propio backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (API REST); ambas opciones admiten la conversión ODP → PPTX.