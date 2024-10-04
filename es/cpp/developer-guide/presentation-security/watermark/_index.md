---
title: Marca de agua
type: docs
weight: 40
url: /es/cpp/watermark/
keywords: "marca de agua en presentación"
description: "Usa marca de agua en PowerPoint con Aspose.Slides. Agrega marca de agua en presentación ppt o elimina marca de agua. Inserta imagen de marca de agua o texto de marca de agua."
---


## **Acerca de la Marca de Agua**
La **marca de agua** en presentación es un sello de texto o imagen, utilizado en una diapositiva o en todas las diapositivas de la presentación. Usualmente, la marca de agua se utiliza para indicar que la presentación es un borrador (por ejemplo, "Borrador" marca de agua); que contiene información confidencial (por ejemplo, "Confidencial" marca de agua); especificar a qué empresa pertenece (por ejemplo, "Nombre de la empresa" marca de agua); identificar al autor de la presentación, etc. La marca de agua ayuda a prevenir la violación de derechos de autor de la presentación, indicando que no debe ser copiada. Las marcas de agua se utilizan tanto con formatos de presentación de PowerPoint como de OpenOffice. En Aspose.Slides puedes agregar marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides para C++**](https://products.aspose.com/slides/cpp/) hay varias formas de crear marca de agua en PowerPoint o OpenOffice, envolverla en diferentes formas, cambiar el diseño y comportamiento, etc. Lo común es que para agregar marcas de agua de texto debes usar la clase [**TextFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame) y para agregar marca de agua de imagen - [**PictureFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame). PictureFrame implementa la interfaz [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) y puede utilizar todo el potencial de configuraciones flexibles del objeto de forma. TextFrame no es una forma y sus configuraciones son limitadas. Por lo tanto, se aconseja envolver TextFrame en un objeto [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape).

Hay dos maneras en que se puede aplicar la marca de agua: a una sola diapositiva y a todas las diapositivas de la presentación. Se utiliza el Master de Diapositivas para aplicar la marca de agua a todas las diapositivas de la presentación: la marca de agua se agrega al Master de Diapositivas, se diseña completamente allí y se aplica a todas las diapositivas sin modificar el permiso para modificar la marca de agua en las diapositivas.

La marca de agua generalmente se considera no disponible para edición por otros usuarios. Para prevenir la edición de la marca de agua (o más bien la forma principal de la marca de agua), Aspose.Slides proporciona funcionalidad de bloqueo de forma. Una cierta forma puede ser bloqueada en una diapositiva normal o en un Master de Diapositivas. Al bloquear la forma de marca de agua en un Master de Diapositivas, se bloqueará en todas las diapositivas de la presentación.

Puedes establecer el nombre de la marca de agua, para que en el futuro, si deseas eliminar la marca de agua, puedas encontrarla en las formas de la diapositiva por su nombre.

Puedes diseñar la marca de agua de cualquier manera, sin embargo, normalmente hay características comunes dentro de las marcas de agua, como: alineación al centro, rotación, posición frontal, etc. Consideraremos cómo utilizarlas en los ejemplos a continuación.
## **Marca de Agua de Texto**
### **Agregar Marca de Agua de Texto a la Diapositiva**
Para agregar una marca de agua de texto en PPT, PPTX o ODP primero puedes agregar una forma en la diapositiva, luego agregar un marco de texto en esta forma. El marco de texto se representa con el tipo [**TextFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame). Este tipo no se hereda de [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape), que tiene un amplio conjunto de propiedades para establecer la marca de agua de una manera flexible. Por lo tanto, se aconseja envolver el objeto [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame) en un objeto [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). Para agregar marca de agua en la forma, utiliza el método [**AddTextFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) con el texto de marca de agua pasado a él:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

auto master = presentation->get_Masters()->idx_get(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 0.0f, 0.0f, 0.0f, 0.0f);

auto watermarkTextFrame = watermarkShape->AddTextFrame(u"Marca de agua");
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/cpp/slide-master/)[TextFrame](/slides/es/cpp/adding-and-formatting-text/)
{{% /alert %}}

### **Agregar Marca de Agua de Texto a la Presentación**
Si deseas agregar una marca de agua en la presentación (es decir, en todas las diapositivas a la vez), agrégala al [**MasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.master_slide). Toda la otra lógica es la misma que al agregar una marca de agua en una sola diapositiva: crea un objeto [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) y luego agrega la marca de agua en él con el método [**AddTextFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3):

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

auto master = presentation->get_Masters()->idx_get(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 0.0f, 0.0f, 0.0f, 0.0f);

auto watermarkTextFrame = watermarkShape->AddTextFrame(u"Marca de agua");
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/cpp/slide-master/)[Master de Diapositivas](/slides/es/cpp/slide-master/)
{{% /alert %}}

### **Establecer Fuente de la Marca de Agua de Texto**
Puedes cambiar la fuente de la marca de agua de texto:

``` cpp
int32_t alpha = 150, red = 200, green = 200, blue = 200;
    
auto watermarkPortion = watermarkTextFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);

watermarkPortion->get_PortionFormat()->set_FontHeight(52.0f);
```


### **Establecer Transparencia de la Marca de Agua de Texto**
Para establecer la transparencia de la marca de agua de texto utiliza este código:

``` cpp
int32_t alpha = 150, red = 200, green = 200, blue = 200;
    
auto watermarkPortion = watermarkTextFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);

watermarkPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);

watermarkPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```


### **Centrar la Marca de Agua de Texto**
Es posible centrar la marca de agua en una diapositiva y para eso puedes hacer lo siguiente:

``` cpp
PointF center(presentation->get_SlideSize()->get_Size().get_Width() / 2, presentation->get_SlideSize()->get_Size().get_Height() / 2);

float width = 300.0f;
float height = 300.0f;

float x = center.get_X() - width / 2;
float y = center.get_Y() - height / 2;

//...

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, x, y, width, height);
```


## **Marca de Agua de Imagen**
### **Agregar Marca de Agua de Imagen a la Presentación**
Para agregar una marca de agua de imagen en todas las diapositivas de la presentación, puedes hacer lo siguiente:

``` cpp
auto image = presentation->get_Images()->AddImage(:File::ReadAllBytes(u"watermark.png"));

// ...

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);

watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```




## **Bloquear Marca de Agua de Edición**
Si es necesario prevenir que la marca de agua sea editada, utiliza el método [**AutoShape::get_AutoShapeLock()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape#a3493d7814106e74ef2213707f64135a8) en la forma, que la envuelve. Con este método puedes proteger la forma de selección, redimensionar, cambiar de posición, agrupar con otros elementos, bloquear su texto de edición y muchos otros:

``` cpp
// Bloquear formas de modificar
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```



{{% alert color="primary" title="Ver también" %}} 
- [Cómo bloquear formas de la edición](/slides/es/cpp/presentation-locking/)
{{% /alert %}}

## **Traer Marca de Agua al Frente**
En Aspose.Slides el orden Z de las formas se puede establecer a través del método [**SlideCollection::Reorder()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad9bc39c557ea8ea3d67e8cec53363c40). Para eso, debes llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De esta manera es posible colocar la forma al frente o atrás de la diapositiva. Esta característica es especialmente útil si necesitas colocar la marca de agua al frente de la presentación:

``` cpp
slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, watermarkShape);
```


## **Establecer Rotación de la Marca de Agua**
Aquí hay un ejemplo de cómo establecer la rotación de la marca de agua (y su forma principal):

``` cpp
int32_t calculateRotation(float height, float width)
{
    double pageHeight = Convert::ToDouble(height);
    double pageWidth = Convert::ToDouble(width);
    
    double rotation = Math::Atan((pageHeight / pageWidth)) * 180 / Math::PI;
    
    return Convert::ToInt32(rotation);
}
```

``` cpp
float h = presentation->get_SlideSize()->get_Size().get_Height();
float w = presentation->get_SlideSize()->get_Size().get_Width();

watermarkShape->set_X(static_cast<float>(System::Convert::ToInt32((w - watermarkShape->get_Width()) / 2)));

watermarkShape->set_Y(static_cast<float>(System::Convert::ToInt32((h - watermarkShape->get_Height()) / 2)));

watermarkShape->set_Rotation(static_cast<float>(calculateRotation(h, w)));
```


## **Establecer Nombre a la Marca de Agua**
Aspose.Slides permite establecer el nombre de la forma. Por el nombre de la forma puedes acceder a ella en el futuro para modificar o eliminar. Para establecer el nombre de la forma principal de la marca de agua - configúralo en el método [**AutoShape::set_Name()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape#ab3df67c6a42fb153d84f58ee69e8b221):

``` cpp
watermarkShape->set_Name(u"marca de agua");
```


## **Eliminar Marca de Agua**
Para eliminar la forma de marca de agua y sus controles secundarios de la diapositiva, utiliza el método [AutoShape.get_Name()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape#a3de41f504e4f9a728c3801159773487e) para encontrarla en las formas de la diapositiva. Luego pasa la forma de marca de agua al método [**ShapeCollection::Remove()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape_collection#a78968527e6f86cced3ffa5c2accab3fc):

``` cpp
for (int32_t i = 0; i < slide->get_Shapes()->get_Count(); i++)
{
	auto shape = ExplicitCast<AutoShape>(slide->get_Shapes()->idx_get(i));
	if (String::Compare(shape->get_Name(), u"marca de agua", StringComparison::Ordinal) == 0)
	{
		slide->get_Shapes()->Remove(watermarkShape);
	}
}
```


## **Ejemplo en Vivo**
Quizás quieras consultar las **herramientas en línea** **gratuitas** de **Aspose.Slides** [**Agregar Marca de Agua**](https://products.aspose.app/slides/watermark) y [**Eliminar Marca de Agua**](https://products.aspose.app/slides/watermark/remove-watermark). 

![todo:image_alt_text](slides-watermark.png)