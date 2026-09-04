---
title: "Automatización de la generación de PowerPoint en Python: crea presentaciones dinámicas con facilidad"
linktitle: Automatización de la generación de PowerPoint
type: docs
weight: 20
url: /es/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- plataformas en la nube
- integración en la nube
- automatizar la generación de PowerPoint
- generar presentaciones programáticamente
- automatización de PowerPoint
- creación dinámica de diapositivas
- informes empresariales automatizados
- automatización de PPT
- presentación en Python
- Python
- Aspose.Slides
description: "Automatiza la generación de PowerPoint con Aspose.Slides para Python a través de Java: crea una presentación empresarial con gráficos, tablas y viñetas en aplicaciones en la nube."
---
## **Introducción**

Crear presentaciones manualmente se vuelve repetitivo cuando su contenido cambia con frecuencia. Los informes semanales, materiales de capacitación y presentaciones para clientes suelen compartir una estructura común pero necesitan datos nuevos para cada entrega.

Aspose.Slides for Python via Java le permite generar estas presentaciones desde aplicaciones Python. Puede integrar la creación de diapositivas en portales web, trabajos programados y workers en la nube, usando datos de bases de datos, API o archivos cargados.

## **Casos de uso habituales para la automatización de PowerPoint en Python**

- **Informes y paneles de negocio:** convierta cifras de ventas y métricas de rendimiento en gráficos y tablas.
- **Presentaciones de ventas personalizadas:** rellene diapositivas con datos específicos del cliente manteniendo un diseño coherente.
- **Contenido educativo:** ensamble lecciones, cuestionarios y resúmenes de cursos a partir de material estructurado.
- **Información basada en datos e IA:** utilice resultados de análisis o servicios de procesamiento del lenguaje como contenido de la presentación.
- **Diapositivas con medios:** combine imágenes o capturas de pantalla cargadas con texto explicativo.
- **Flujos de trabajo de documentos:** mapée contenido extraído por otras herramientas a diseños de presentación.
- **Herramientas para desarrolladores:** genere resúmenes de versiones, visión general técnica o demostraciones a partir de datos del proyecto.

## **Requisitos previos**

Siga [Installation](/slides/es/python-java/installation/) para configurar Python, Java, JPype y Aspose.Slides. Para implementaciones en la nube, revise también [Slides on Cloud Platforms](/slides/es/python-java/slides-on-cloud-platforms/).

El ejemplo utiliza datos de negocio fijos para que pueda ejecutarse sin una base de datos ni un servicio externo. Sustituya estos valores por datos de su aplicación cuando lo integre en un flujo de trabajo de informes.

{{% alert color="info" title="Nota" %}}

Puede probar el ejemplo sin una licencia, pero la salida de evaluación incluye una marca de agua y está sujeta a restricciones de evaluación. Consulte [Evaluate Aspose.Slides](/slides/es/python-java/evaluate-aspose-slides/) para obtener más detalles e información sobre licencias temporales.

{{% /alert %}}

## **Crear la presentación**

El script completo a continuación crea una presentación que contiene cuatro diapositivas. Cada paso utiliza la misma presentación, y el paso final la guarda como `presentation.pptx`.

### **Crear una diapositiva de título**

Use la diapositiva inicial en una nueva [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y aplique el diseño de título. Rellene sus marcadores de posición de título y subtítulo con el encabezado del informe y la audiencia.

![The title slide](slide_0.png)

### **Añadir una diapositiva con un gráfico de columnas**

Añada una diapositiva en blanco y cree un gráfico con [ShapeCollection.addChart](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addChart). Complete su libro incrustado con cinco regiones y una serie de ventas. Los valores permanecen editables en PowerPoint.

![The slide with the chart](slide_1.png)

### **Añadir una diapositiva con una tabla**

Cree una tabla con [ShapeCollection.addTable](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addTable) y rellene dos columnas con nombres de métricas y valores. El ejemplo pasa matrices Java explícitas de doubles para los anchos de columna y las alturas de fila a través de JPype.

![The slide with the table](slide_2.png)

### **Añadir una diapositiva de resumen con viñetas**

Cree una forma de texto y añada un [Paragraph](https://reference.aspose.com/slides/es/python-java/aspose.slides/paragraph/) para cada elemento de acción. Aplique una viñeta de símbolo y texto negro a cada párrafo, y elimine el relleno y el contorno de la forma.

![The slide with the summary](slide_3.png)

### **Guardar la presentación**

Utilice [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) para escribir el archivo PowerPoint. Libere la presentación con [Presentation.dispose](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#dispose) en un bloque `finally`.

### **Ejemplo completo en Python**

Guarde este script en un directorio con permisos de escritura y ejecútelo con el entorno Python configurado arriba. Inicia la JVM solo si es necesario y la mantiene disponible hasta que el proceso finalice. Para uso en cuadernos y servicios, consulte [JVM lifecycle guidance](/slides/es/python-java/limitations-and-api-differences/#import-the-library).

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # Crear la diapositiva de título.
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # Añadir una diapositiva con un gráfico.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Añadir una diapositiva con una tabla.
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # Añadir una diapositiva de resumen.
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Las ilustraciones muestran las diapositivas correspondientes del ejemplo en Java. La apariencia puede variar según las fuentes instaladas y el modo de evaluación.

## **Usar el ejemplo en una aplicación en la nube**

Obtenga los datos del informe antes de crear la presentación, luego páselos a los pasos de gráfico, tabla y generación de texto. Utilice una ruta de salida distinta para cada trabajo. Tras guardar, su aplicación puede subir el archivo a un almacenamiento de objetos o devolverlo como descarga.

Mantenga la JVM ejecutándose entre trabajos dentro del mismo proceso worker y libere cada presentación cuando finalice su trabajo. Empaquete las fuentes requeridas por el diseño de su informe con la implementación para reducir diferencias entre entornos.

## **Conclusión**

Este ejemplo genera una presentación empresarial completa desde Python con gráficos, tablas y texto editables. Sustituir los datos de muestra por los datos de su aplicación hace que el mismo enfoque sea útil para informes recurrentes, presentaciones a clientes y material educativo.

## **Preguntas frecuentes**

**¿El script necesita Microsoft PowerPoint o Excel?**

No. Aspose.Slides crea las diapositivas y el libro incrustado del gráfico sin ninguna de esas aplicaciones.

**¿Por qué el ejemplo de tabla utiliza matrices Java?**

El método subyacente acepta matrices de doubles de Java. Las matrices explícitas clarifican los tipos numéricos que se pasan a través de JPype.

**¿Puedo guardar la misma presentación como PDF o ODP?**

Sí. Antes de disponer de ella, guárdela con otro nombre de archivo de salida usando el valor correspondiente de [SaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/). Consulte [Supported File Formats](/slides/es/python-java/supported-file-formats/) para conocer las capacidades específicas de cada formato.

**¿Puedo usar una plantilla con marca?**

Sí. Cargue su plantilla en lugar de crear una presentación vacía, luego adapte el diseño y la selección de marcadores de posición a esa plantilla. El ejemplo asume los diseños y el orden de marcadores de posición de una nueva presentación predeterminada.