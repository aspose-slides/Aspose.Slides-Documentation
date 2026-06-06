---
title: Gestionar listas con viñetas y numeradas en presentaciones en C++
linktitle: Gestionar listas
type: docs
weight: 70
url: /es/cpp/manage-lists/
keywords:
- viñeta
- lista con viñetas
- lista numerada
- viñeta de símbolo
- viñeta con imagen
- viñeta personalizada
- lista multinivel
- crear viñeta
- añadir viñeta
- añadir lista
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda a crear y dar formato a listas con viñetas, con imágenes, multinivel y numeradas en presentaciones PowerPoint y OpenDocument usando Aspose.Slides para C++."
---
## **Descripción general**

Aspose.Slides for C++ le permite crear y dar formato a listas con viñetas y numeradas en presentaciones PowerPoint y OpenDocument. Un elemento de lista es un párrafo cuyas configuraciones de viñeta se controlan mediante su formato de párrafo.

Utilice el [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraph/get_paragraphformat/) para acceder a la configuración de listas a nivel de párrafo. El punto de entrada principal es [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/get_bullet/), que devuelve un objeto [IBulletFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/). Con este objeto, puede establecer el tipo de viñeta, símbolo, imagen, color, tamaño, estilo de numeración y número inicial.

Este artículo muestra cómo:

- crear una lista con viñetas y un símbolo personalizado
- crear una viñeta con imagen
- crear una lista multinivel estableciendo la profundidad del párrafo
- crear una lista numerada
- inspeccionar y cambiar el formato de listas en una presentación existente

## **Crear una lista con viñetas**

Para crear una lista con viñetas, añada objetos [Paragraph](https://reference.aspose.com/slides/es/cpp/aspose.slides/paragraph/) a un [ITextFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/) y establezca [IBulletFormat::set_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_type/) a [BulletType::Symbol](https://reference.aspose.com/slides/es/cpp/aspose.slides/bullettype/). Después, puede definir [IBulletFormat::set_Char](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/get_color/) y [IBulletFormat::set_Height](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_height/) para controlar la apariencia de la viñeta.

El siguiente código C++ muestra cómo crear una lista con viñetas en una diapositiva:

```cpp
auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![Viñetas de símbolo](symbol_bullets.png)

## **Crear una lista numerada**

Utilice listas numeradas cuando el orden de los elementos sea importante. Establezca [IBulletFormat::set_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_type/) a [BulletType::Numbered](https://reference.aspose.com/slides/es/cpp/aspose.slides/bullettype/). También puede elegir un formato de numeración con [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) o establecer [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) cuando la lista deba comenzar con un valor distinto de 1.

El siguiente código C++ muestra cómo crear una lista numerada en una diapositiva:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![Viñetas numeradas](numbered_bullets.png)

## **Crear una viñeta con imagen**

Aspose.Slides le permite sustituir un símbolo de viñeta normal por una imagen. Las viñetas con imagen funcionan mejor con imágenes simples que sigan siendo legibles en tamaño pequeño, como íconos o archivos PNG transparentes de pequeño tamaño.

{{% alert color="primary" %}}
Idealmente, si planea sustituir el símbolo de viñeta normal por una imagen, lo mejor es elegir un gráfico sencillo con fondo transparente. Ese tipo de imágenes funciona bien como símbolos de viñeta personalizados.

Tenga en cuenta que la imagen se reducirá a un tamaño muy pequeño. Por esa razón, recomendamos encarecidamente seleccionar una imagen que siga siendo clara y visualmente eficaz cuando se use como viñeta en una lista.
{{% /alert %}}

Para crear una viñeta con imagen, añada una imagen a [IPresentation::get_Images](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_images/) y asigne el objeto [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) devuelto a [IBulletFormat::get_Picture](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/get_picture/). Establezca [IBulletFormat::set_Type](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibulletformat/set_type/) a [BulletType::Picture](https://reference.aspose.com/slides/es/cpp/aspose.slides/bullettype/) antes de asignar la imagen.

Supongamos que disponemos de un “image.png”:

![Una imagen para las viñetas](picture_for_bullets.png)

El siguiente código C++ muestra cómo crear viñetas con imagen en una diapositiva:

```cpp
auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![Viñetas con imagen](picture_bullets.png)

## **Crear una lista multinivel**

Utilice [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/set_depth/) para colocar los elementos de la lista en diferentes niveles. El nivel 0 es el nivel superior, el nivel 1 está anidado bajo él, y así sucesivamente.

El siguiente código C++ muestra cómo crear una lista con viñetas multinivel:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El resultado:

![Lista multinivel](multilevel_list.png)

## **Cambiar una lista existente**

Para modificar el formato de lista en una presentación existente, acceda al párrafo objetivo y actualice su configuración [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/get_bullet/). Las mismas propiedades utilizadas para crear listas pueden emplearse para inspeccionar o modificar listas cargadas desde un archivo PPT, PPTX o ODP.

El siguiente código C++ cambia el primer párrafo de un marco de texto para que use un estilo de lista numerada:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**¿Se pueden exportar listas con viñetas y numeradas a PDF o imágenes?**

Sí. Aspose.Slides conserva el formato de la lista cuando el formato de destino admite la disposición de texto y las características de viñetas correspondientes.

**¿Puedo editar listas en presentaciones existentes?**

Sí. Cargue la presentación, acceda al párrafo objetivo, inspeccione o actualice su configuración [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/es/cpp/aspose.slides/iparagraphformat/get_bullet/) y guarde la presentación.

**¿Las listas pueden contener texto no latino?**

Sí. El texto de los elementos de la lista puede contener caracteres Unicode, por lo que puede crear listas en presentaciones multilingües. Asegúrese de que las fuentes utilizadas en la presentación admitan los caracteres que necesita.