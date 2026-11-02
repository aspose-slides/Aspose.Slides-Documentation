---
title: Gerenciar Listas com Marcadores e Numeradas em Apresentações em C++
linktitle: Gerenciar Listas
type: docs
weight: 70
url: /pt/cpp/manage-lists/
keywords:
- marcador
- lista com marcadores
- lista numerada
- marcador de símbolo
- marcador de imagem
- marcador personalizado
- lista multinível
- criar marcador
- adicionar marcador
- adicionar lista
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a criar e formatar listas com marcadores, de imagem, multiníveis e numeradas em apresentações PowerPoint e OpenDocument usando Aspose.Slides para C++."
---
## **Visão geral**

Aspose.Slides for C++ permite criar e formatar listas com marcadores e numeradas em apresentações PowerPoint e OpenDocument. Um item de lista é um parágrafo cujas configurações de marcador são controladas por seu formato de parágrafo.

Use o método [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_paragraphformat/) para acessar as configurações de lista ao nível de parágrafo. O ponto de entrada principal é [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/), que retorna um objeto [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/). Com esse objeto, você pode definir o tipo de marcador, símbolo, imagem, cor, tamanho, estilo de numeração e número inicial.

Este artigo mostra como:

- criar uma lista com marcadores usando um símbolo personalizado
- criar um marcador de imagem
- criar uma lista multinível definindo a profundidade do parágrafo
- criar uma lista numerada
- inspecionar e alterar a formatação da lista em uma apresentação existente
- ler os marcadores de lista reais e os números ao lado do texto do parágrafo

## **Criar uma lista com marcadores**

Para criar uma lista com marcadores, adicione objetos [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) ao [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) e defina [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) para [BulletType::Symbol](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/). Em seguida, você pode definir [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_color/) e [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) para controlar a aparência do marcador.

O código C++ a seguir demonstra como criar uma lista com marcadores em um slide:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

O resultado:

![Os marcadores de símbolo](symbol_bullets.png)

## **Criar uma lista numerada**

Use listas numeradas quando a ordem dos itens for importante. Defina [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) para [BulletType::Numbered](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/). Você também pode escolher um formato de numeração com [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) ou definir [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) quando a lista deve começar a partir de um valor diferente de 1.

O código C++ a seguir mostra como criar uma lista numerada em um slide:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

O resultado:

![Os marcadores numerados](numbered_bullets.png)

## **Criar um marcador de imagem**

Aspose.Slides permite substituir um símbolo de marcador comum por uma imagem. Marcadores de imagem funcionam melhor com imagens simples que permanecem legíveis em tamanho pequeno, como ícones ou pequenos arquivos PNG transparentes.

 {{% alert color="info" title="Note" %}}
Idealmente, se você pretende substituir o símbolo de marcador comum por uma imagem, é melhor escolher um gráfico simples com fundo transparente. Essas imagens funcionam bem como símbolos de marcador personalizados.
Lembre-se de que a imagem será reduzida a um tamanho muito pequeno. Por esse motivo, recomendamos enfaticamente selecionar uma imagem que permaneça nítida e visualmente eficaz quando usada como marcador em uma lista.
{{% /alert %}}

Para criar um marcador de imagem, adicione uma imagem ao [IPresentation::get_Images](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_images/) e atribua o objeto [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) retornado a [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/). Defina [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) para [BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) antes de atribuir a imagem.

Suponha que temos um "image.png":

![Uma imagem para os marcadores](picture_for_bullets.png)

O código C++ a seguir mostra como criar marcadores de imagem em um slide:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

O resultado:

![Os marcadores de imagem](picture_bullets.png)

## **Criar uma lista multinível**

Use [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) para colocar itens de lista em diferentes níveis. O nível 0 é o nível superior, o nível 1 está aninhado abaixo dele e assim por diante.

O código C++ a seguir mostra como criar uma lista com marcadores multinível:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

O resultado:

![A lista multinível](multilevel_list.png)

## **Alterar uma lista existente**

Para alterar a formatação da lista em uma apresentação existente, acesse o parágrafo alvo e atualize suas configurações [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/). As mesmas propriedades usadas para criar listas podem ser usadas para inspecionar ou modificar listas carregadas de um arquivo PPT, PPTX ou ODP.

O código C++ a seguir altera o primeiro parágrafo em um quadro de texto para usar um estilo de lista numerada:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

## **Ler valores reais de marcadores**

Ao extrair o conteúdo de uma apresentação, mantenha os marcadores de lista junto ao texto do parágrafo. Chame [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/) e acesse [IParagraphFormatEffectiveData::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformateffectivedata/get_bullet/) para obter o formato efetivo do marcador. Verifique seu [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_type/) antes de ler [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/).

Para listas numeradas, distinga estes três valores:

- [get_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstyle/) determina o formato, como números arábicos seguidos por ponto ou letras minúsculas seguidas por ponto.
- [get_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_numberedbulletstartwith/) especifica o número inicial para um grupo de parágrafos numerados.
- [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) retorna o marcador formatado para um parágrafo específico. Por exemplo, o segundo item de uma lista que começa em 5 retorna `6.`.

Preserve [IParagraphFormat::get_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_depth/) em cada parágrafo para manter seu nível de aninhamento. O marcador real não codifica toda a hierarquia: um item aninhado pode retornar `c.` em vez de um rótulo combinado como `6.c.`.

O exemplo autônomo a seguir cria listas, salva-as em uma apresentação e recarrega a apresentação para relatar o texto, a profundidade, o tipo de marcador e o valor real de cada parágrafo. O pequeno marcador de imagem azul é criado a partir de SVG embutido.

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IBulletFormat.h>
#include <DOM/IBulletFormatEffectiveData.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

{
    auto presentation = System::MakeObject<Presentation>();
    presentation->get_SlideSize()->SetSize(720, 440, SlideSizeScaleType::DoNotScale);
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    auto textFrame = shape->get_TextFrame();
    textFrame->get_Paragraphs()->Clear();

    // Criar um marcador de imagem sem um arquivo de imagem externo.
    auto svg = System::MakeObject<SvgImage>(u"<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    auto bulletImage = presentation->get_Images()->AddImage(svg);

    auto addParagraph = [&](System::String text, int16_t depth, BulletType type, int16_t start = 1, NumberedBulletStyle style = NumberedBulletStyle::BulletArabicPeriod)
    {
        auto paragraph = System::MakeObject<Paragraph>();
        paragraph->set_Text(text);

        auto format = paragraph->get_ParagraphFormat();
        format->set_Depth(depth);
        format->set_MarginLeft(30 + depth * 40);
        format->set_Indent(-28);
        format->set_SpaceAfter(8);
        format->get_DefaultPortionFormat()->set_FontHeight(22);
        format->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
        format->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
        auto bullet = format->get_Bullet();
        bullet->set_Type(type);
        bullet->set_IsBulletHardColor(NullableBool::True);
        bullet->get_Color()->set_Color(Color::get_Black());
        if (type == BulletType::Numbered)
        {
            bullet->set_NumberedBulletStyle(style);
            bullet->set_NumberedBulletStartWith(start);
        }
        else if (type == BulletType::Symbol)
        {
            bullet->set_Char(u'\u2022');
        }
        else if (type == BulletType::Picture)
        {
            bullet->get_Picture()->set_Image(bulletImage);
        }

        textFrame->get_Paragraphs()->Add(paragraph);
    };

    addParagraph(u"First item", 0, BulletType::Numbered, 5);
    addParagraph(u"Second item", 0, BulletType::Numbered, 5);
    addParagraph(u"Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    addParagraph(u"Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    addParagraph(u"Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    addParagraph(u"Back to top level", 0, BulletType::Numbered, 5);
    addParagraph(u"Symbol marker", 0, BulletType::Symbol);
    addParagraph(u"No bullet", 0, BulletType::None);
    addParagraph(u"Picture marker", 0, BulletType::Picture);
    presentation->Save(u"actual_bullet_values.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}

auto loadedPresentation = System::MakeObject<Presentation>(u"actual_bullet_values.pptx");
auto loadedShape = System::ExplicitCast<IAutoShape>(loadedPresentation->get_Slide(0)->get_Shape(0));
System::Console::WriteLine(u"Text | Depth | Type | Actual value");
for (auto paragraph : loadedShape->get_TextFrame()->get_Paragraphs())
{
    auto bullet = paragraph->get_ParagraphFormat()->GetEffective()->get_Bullet();
    auto actualValue = bullet->get_ActualBulletValue();
    System::String marker;
    switch (bullet->get_Type())
    {
        case BulletType::Numbered:
        case BulletType::Symbol:
            marker = actualValue;
            break;
        case BulletType::None:
            marker = (actualValue.IsNull() ? System::String(u"null") : actualValue) + u" (no bullet)";
            break;
        case BulletType::Picture:
            marker = (actualValue.IsNull() ? System::String(u"null") : actualValue) + u" (image required)";
            break;
        default:
            marker = u"unsupported bullet type";
            break;
    }
    System::Console::WriteLine(u"{0} | {1} | {2} | {3}", paragraph->get_Text(), paragraph->get_ParagraphFormat()->get_Depth(), bullet->get_Type(), marker);
}
loadedPresentation->Dispose();
```

As listas de origem são exibidas abaixo.

![Listas iniciando em 5, itens aninhados com letra e número romano, um marcador de símbolo, um parágrafo sem marcador e um marcador de imagem azul](actual_bullet_values.png)

O relatório corresponde aos marcadores exibidos no PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Para [BulletType::None e BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/), [get_ActualBulletValue](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformateffectivedata/get_actualbulletvalue/) retorna um `System::String` nulo, não uma string vazia. Use `IsNull` para verificar esse valor. Trate esses tipos separadamente: o primeiro não possui marcador, enquanto o último requer a extração da imagem do marcador separadamente. Um marcador de imagem não pode ser reproduzido apenas extraindo um marcador de texto.

## **Perguntas frequentes**

**As listas com marcadores e numeradas podem ser exportadas para PDF ou imagens?**

Sim. Aspose.Slides preserva a formatação da lista quando o formato de destino suporta o layout de texto correspondente e os recursos de marcadores.

**Posso editar listas em apresentações existentes?**

Sim. Carregue a apresentação, acesse o parágrafo alvo, inspecione ou atualize suas configurações [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/get_bullet/) e salve a apresentação.

**As listas podem conter texto não‑latino?**

Sim. O texto dos itens de lista pode conter caracteres Unicode, portanto você pode criar listas em apresentações multilingues. Certifique‑se de que as fontes usadas na apresentação suportam os caracteres necessários.