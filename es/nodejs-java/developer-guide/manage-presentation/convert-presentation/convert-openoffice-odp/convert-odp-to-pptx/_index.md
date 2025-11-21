---
title: Convertir ODP a PPTX
type: docs
weight: 10
url: /es/nodejs-java/convert-odp-to-pptx/
---

## **Convertir ODP a Presentación PPTX/PPT**
Aspose.Slides para Node.js a través de Java ofrece la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) que representa un archivo de presentación. La clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) ahora también puede acceder a ODP mediante el constructor [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) cuando se instancia el objeto. El siguiente ejemplo muestra cómo convertir una presentación ODP en una presentación PPTX.
```javascript
// Abrir el archivo ODP
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// Guardar la presentación ODP en formato PPTX
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **Ejemplo en Vivo**
Puede visitar la aplicación web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) que está construida con **Aspose.Slides API.** La aplicación muestra cómo se puede implementar la conversión de ODP a PPTX con Aspose.Slides API.

## **Preguntas frecuentes**

**¿Necesito instalar Microsoft PowerPoint o LibreOffice para convertir ODP a PPTX?**

No. Aspose.Slides funciona de manera independiente y no requiere aplicaciones de terceros para leer o escribir ODP/PPTX.

**¿Se conservan las diapositivas maestras, diseños y temas durante la conversión?**

Sí. La biblioteca utiliza un modelo de objeto de presentación completo y mantiene la estructura, incluidas las diapositivas maestras y los diseños, de modo que el diseño permanece correcto después de la conversión.

**¿Puedo convertir archivos ODP protegidos con contraseña?**

Sí. Aspose.Slides admite la detección de protección, la apertura y el trabajo con [presentaciones protegidas](/slides/es/nodejs-java/password-protected-presentation/) (incluido ODP) cuando se proporciona la contraseña, así como la configuración del cifrado y el acceso a las propiedades del documento.

**¿Es Aspose.Slides adecuado para servicios de conversión en la nube o basados en REST?**

Sí. Puede usar la biblioteca local en su propio backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/) (API REST); ambas opciones admiten la conversión ODP → PPTX.