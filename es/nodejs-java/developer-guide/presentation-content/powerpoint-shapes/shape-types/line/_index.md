---
title: Línea
type: docs
weight: 50
url: /es/nodejs-java/Line/
---

{{% alert color="primary" %}} 
Aspose.Slides for Node.js via Java admite agregar diferentes tipos de formas a las diapositivas. En este tema, comenzaremos a trabajar con formas añadiendo líneas a las diapositivas. Con Aspose.Slides for Node.js via Java, los desarrolladores pueden no solo crear líneas simples, sino que también pueden dibujar líneas más elaboradas en las diapositivas.
{{% /alert %}} 

## **Crear línea simple**

Para agregar una línea simple a una diapositiva seleccionada de la presentación, siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva mediante su Índice.
- Agregue un AutoShape de tipo Línea utilizando el método [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Guarde la presentación modificada como un archivo PPTX.

En el ejemplo a continuación, hemos agregado una línea a la primera diapositiva de la presentación.
```javascript
// Instanciar la clase PresentationEx que representa el archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añadir un AutoShape de tipo línea
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Guardar el PPTX en disco
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Crear línea con forma de flecha**

Aspose.Slides for Node.js via Java también permite a los desarrolladores configurar algunas propiedades de la línea para que resulte más atractiva. Vamos a intentar configurar algunas propiedades de una línea para que tenga forma de flecha. Siga los pasos a continuación:

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenga la referencia de una diapositiva mediante su Índice.
- Agregue un AutoShape de tipo Línea utilizando el método [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) expuesto por el objeto [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).
- Establezca el [Estilo de línea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineStyle) a uno de los estilos ofrecidos por Aspose.Slides for Node.js via Java.
- Establezca el ancho de la línea.
- Establezca el [Estilo de guión](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineDashStyle) de la línea a uno de los estilos ofrecidos por Aspose.Slides for Node.js via Java.
- Establezca el [Estilo de cabeza de flecha](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) y la [Longitud](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) del punto de inicio de la línea.
- Establezca el [Estilo de cabeza de flecha](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadStyle) y la [Longitud](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LineArrowheadLength) del punto final de la línea.
- Guarde la presentación modificada como un archivo PPTX.
```javascript
// Instanciar la clase PresentationEx que representa el archivo PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Añadir un AutoShape de tipo línea
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Aplicar algo de formato a la línea
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Guardar el PPTX en disco
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Preguntas frecuentes**

**¿Puedo convertir una línea regular en un conector para que se “ajuste” a las formas?**

No. Una línea regular (un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) de tipo [Line](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/)) no se convierte automáticamente en un conector. Para que se ajuste a las formas, use el tipo [Connector](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connector/) dedicado y las [APIs correspondientes](/slides/es/nodejs-java/connector/) para conexiones.

**¿Qué debo hacer si las propiedades de una línea se heredan del tema y es difícil determinar los valores finales?**

[Lea las propiedades efectivas](/slides/es/nodejs-java/shape-effective-properties/) a través de las clases `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData`; estas ya tienen en cuenta la herencia y los estilos del tema.

**¿Puedo bloquear una línea contra la edición (mover, cambiar de tamaño)?**

Sí. Las formas proporcionan [objetos de bloqueo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/getautoshapelock/) que le permiten [denegar operaciones de edición](/slides/es/nodejs-java/applying-protection-to-presentation/).