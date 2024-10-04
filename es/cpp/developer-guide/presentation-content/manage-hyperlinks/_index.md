---
title: Gestionar Hipervínculos
type: docs
weight: 20
url: /cpp/manage-hyperlinks/
keywords: "Hipervínculo de PowerPoint, hipervínculo de texto, hipervínculo de diapositiva, hipervínculo de forma, hipervínculo de imagen, hipervínculo de video, C++"
description: "Cómo agregar hipervínculo a una presentación de PowerPoint en C++"
---

Un hipervínculo es una referencia a un objeto o dato o un lugar en algo. Estos son hipervínculos comunes en presentaciones de PowerPoint:

* Enlaces a sitios web dentro de textos, formas o medios
* Enlaces a diapositivas

Aspose.Slides para C++ te permite realizar muchas tareas relacionadas con hipervínculos en presentaciones.

{{% alert color="primary" %}} 

Quizás quieras echar un vistazo al editor simple y [gratuito de PowerPoint en línea de Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Agregar Hipervínculos URL**

### **Agregar Hipervínculos URL a Textos**

Este código C++ te muestra cómo agregar un hipervínculo de sitio web a un texto:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Más del 70% de las empresas Fortune 100 confían en las APIs de Aspose");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Agregar Hipervínculos URL a Formas o Marcos**

Este código de muestra en C++ te muestra cómo agregar un hipervínculo de sitio web a una forma:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Más del 70% de las empresas Fortune 100 confían en las APIs de Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

### **Agregar Hipervínculos URL a Medios**

Aspose.Slides permite agregar hipervínculos a archivos de imágenes, audio y video.

Este código de muestra te muestra cómo agregar un hipervínculo a una **imagen**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// Agrega imagen a la presentación
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Crea un marco de imagen en la diapositiva 1 basado en la imagen previamente agregada
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"Más del 70% de las empresas Fortune 100 confían en las APIs de Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

 Este código de muestra te muestra cómo agregar un hipervínculo a un **archivo de audio**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"Más del 70% de las empresas Fortune 100 confían en las APIs de Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

 Este código de muestra te muestra cómo agregar un hipervínculo a un **video**:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"Más del 70% de las empresas Fortune 100 confían en las APIs de Aspose");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

{{%  alert  title="Consejo"  color="primary"  %}} 

Quizás quieras ver *[Gestionar OLE](https://docs.aspose.com/slides/cpp/manage-ole/)*.

{{% /alert %}}



## **Usar Hipervínculos para Crear una Tabla de Contenidos**

Dado que los hipervínculos te permiten agregar referencias a objetos o lugares, puedes usarlos para crear una tabla de contenidos.

Este código de muestra te muestra cómo crear una tabla de contenidos con hipervínculos:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Título de la diapositiva 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Pág. 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```


## **Formatear Hipervínculos**

### **Color**

Con los métodos [set_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) y [get_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) en la interfaz [IHyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink), puedes establecer el color para hipervínculos y también obtener la información del color de los hipervínculos. La función se introdujo por primera vez en PowerPoint 2019, por lo que los cambios relacionados con la propiedad no se aplican a versiones anteriores de PowerPoint.

Este código de muestra demuestra una operación donde se agregaron hipervínculos de diferentes colores a la misma diapositiva:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"Este es un ejemplo de hipervínculo de color.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"Este es un ejemplo de hipervínculo habitual.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```


## **Eliminar Hipervínculos en Presentaciones**

### **Eliminar Hipervínculos de Textos**

Este código C++ te muestra cómo eliminar el hipervínculo de un texto en una diapositiva de presentación:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```

### **Eliminar Hipervínculos de Formas o Marcos**

Este código C++ te muestra cómo eliminar el hipervínculo de una forma en una diapositiva de presentación: 

``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```



## **Hipervínculo Mutable**

La clase [Hyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.hyperlink) es mutable. Con esta clase, puedes cambiar los valores para estos métodos:

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

El fragmento de código te muestra cómo agregar un hipervínculo a una diapositiva y editar su tooltip más tarde:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"Más del 70% de las empresas Fortune 100 confían en las APIs de Aspose");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```




## **Métodos compatibles en IHyperlinkQueries**

Puedes acceder a IHyperlinkQueries desde una presentación, diapositiva o texto para el cual se define el hipervínculo.

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

La clase IHyperlinkQueries admite estos métodos: 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)