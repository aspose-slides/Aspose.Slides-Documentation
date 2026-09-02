---
title: Gerenciar parágrafos de texto do PowerPoint em C++
linktitle: Gerenciar Parágrafo
type: docs
weight: 40
url: /pt/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- adicionar texto
- adicionar parágrafo
- gerenciar texto
- gerenciar parágrafo
- gerenciar marcador
- recuo de parágrafo
- recuo suspenso
- marcador de parágrafo
- lista numerada
- lista com marcadores
- propriedades do parágrafo
- importar HTML
- texto para HTML
- parágrafo para HTML
- parágrafo para imagem
- texto para imagem
- exportar parágrafo
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como criar e formatar parágrafos, porções, marcadores, listas numeradas, recuos, conteúdo HTML e imagens de parágrafos com Aspose.Slides para C++."
---
## **Visão geral**

Aspose.Slides for C++ representa o texto como uma hierarquia de quadros de texto, parágrafos e porções:

* [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) representa o contêiner de texto em uma forma e fornece acesso à sua coleção de parágrafos.
* [IParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/) representa um parágrafo em um quadro de texto e fornece acesso às suas porções e à formatação em nível de parágrafo.
* [IPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/) representa uma corrida de texto dentro de um parágrafo. Cada porção pode ter seu próprio texto e formatação de nível de caractere.

Um parágrafo, portanto, pode conter texto com diferentes fontes, cores, tamanhos e outras formatações usando várias porções.

## **Criar e formatar parágrafos**

### **Criar parágrafos com várias porções**

As etapas a seguir criam um quadro de texto com três parágrafos, cada um contendo três porções:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse a referência do slide desejado através de seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) retangular ao slide.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da forma.
5. Use o parágrafo padrão e adicione mais dois objetos [IParagraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/) ao quadro de texto.
6. Adicione objetos [IPortion](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/) suficientes para que cada parágrafo contenha três porções. O parágrafo padrão já contém uma porção vazia.
7. Defina o texto de cada porção.
8. Aplique formatação de nível de caractere através de [IPortion::get_PortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/get_portionformat/).
9. Salve a apresentação modificada.

Este exemplo em C++ implementa as etapas:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Criar listas com marcadores e numeradas**

### **Criar uma lista com marcadores ou numerada**

Marcadores e numeração facilitam a leitura de itens relacionados. No Aspose.Slides, as configurações de lista são definidas através de [IBulletFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/).

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse a referência do slide desejado através de seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) ao slide selecionado.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da forma.
5. Remova o parágrafo padrão do quadro de texto.
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraph/) para um marcador de símbolo.
7. Defina [IBulletFormat::set_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_type/) como [BulletType::Symbol](https://reference.aspose.com/slides/pt/cpp/aspose.slides/bullettype/) e especifique o caractere do marcador.
8. Defina o texto do parágrafo, recuo, cor do marcador e altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Crie um segundo parágrafo e defina [IBulletFormat::set_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_type/) como [BulletType::Numbered](https://reference.aspose.com/slides/pt/cpp/aspose.slides/bullettype/).
11. Configure o estilo de marcador numerado e adicione o parágrafo ao quadro de texto.
12. Salve a apresentação.

Este exemplo em C++ cria um marcador de símbolo e um marcador numerado:

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Usar marcadores de imagem**

Marcadores de imagem permitem usar uma imagem personalizada em vez de um símbolo ou número.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse a referência do slide desejado através de seu índice.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) e acesse seu [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/).
4. Remova o parágrafo padrão do quadro de texto.
5. Carregue a imagem do marcador e adicione-a à coleção de imagens da apresentação como um [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/).
6. Crie um [Paragraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraph/) e defina seu texto.
7. Defina [IBulletFormat::set_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_type/) como [BulletType::Picture](https://reference.aspose.com/slides/pt/cpp/aspose.slides/bullettype/).
8. Atribua a imagem através de [ISlidesPicture::set_Image](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidespicture/set_image/) e defina a altura do marcador.
9. Adicione o parágrafo ao quadro de texto.
10. Salve a apresentação modificada.

Este exemplo em C++ cria um marcador de imagem:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **Criar uma lista multinível**

Defina [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_depth/) para posicionar parágrafos em diferentes níveis de uma lista. O nível superior tem profundidade `0`.

1. Crie uma [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e acesse um slide.
2. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) e limpe o parágrafo padrão de seu quadro de texto.
3. Crie quatro parágrafos e configure seus símbolos de marcador.
4. Defina seus valores de [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_depth/) para `0`, `1`, `2` e `3`.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

Este exemplo em C++ cria uma lista com marcadores de quatro níveis:

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Iniciar itens numerados da lista com valores personalizados**

Use [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) para definir o número inicial exibido para um parágrafo numerado.

1. Crie uma [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) a um slide.
2. Limpe o parágrafo padrão do quadro de texto da forma.
3. Crie três parágrafos numerados.
4. Defina [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) para `2`, `3` e `7` nos respectivos parágrafos.
5. Adicione os parágrafos ao quadro de texto e salve a apresentação.

Este exemplo em C++ atribui um número inicial personalizado a cada parágrafo:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Controlar layout de parágrafo e propriedades de fim**

### **Definir recuo da primeira linha**

Use [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/) para controlar o recuo da primeira linha de um parágrafo. Esse método desloca apenas a primeira linha em relação à margem esquerda do parágrafo. Um valor positivo desloca a primeira linha para a direita, enquanto as linhas restantes permanecem alinhadas ao corpo do parágrafo.

Use [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_marginleft/) quando precisar mover todo o parágrafo. Use [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/) quando precisar mover apenas a primeira linha.

O exemplo abaixo cria vários parágrafos e aplica diferentes valores de [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/) para demonstrar como o recuo da primeira linha afeta o layout do parágrafo.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) retangular ao slide.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da forma e remova o parágrafo padrão.
5. Crie vários parágrafos e defina diferentes valores de [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/) para eles.
6. Adicione os parágrafos ao quadro de texto.
7. Salve a apresentação modificada.

Este código mostra como definir o recuo de um parágrafo:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Definir recuo suspenso**

Um recuo suspenso é um layout de parágrafo em que a primeira linha começa à esquerda das linhas restantes. No Aspose.Slides, você cria esse efeito com [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/). Defina o recuo como um valor negativo para mover a primeira linha para a esquerda em relação ao corpo do parágrafo.

Na prática, [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_marginleft/) define a posição esquerda do corpo do parágrafo, e [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/) define a posição da primeira linha em relação a essa margem. Para criar um recuo suspenso, defina um valor positivo para margin-left e um valor negativo para indent.

Essa formatação é útil para bibliografias, referências, entradas de glossário e outros parágrafos onde as linhas dobradas devem alinhar sob o corpo do parágrafo e não sob o primeiro caractere da primeira linha.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse o slide de destino.
3. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) retangular ao slide.
4. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da forma e remova o parágrafo padrão.
5. Crie parágrafos e defina um valor positivo de [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_marginleft/) para cada parágrafo.
6. Defina um valor negativo de [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_indent/) para criar o efeito de recuo suspenso.
7. Adicione os parágrafos ao quadro de texto.
8. Salve a apresentação modificada.

Este código mostra como definir um recuo suspenso para um parágrafo:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The hanging indent of the paragraphs](hanging_indent.png)

### **Definir propriedades de execução do fim do parágrafo**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) controla a formatação da marca de fim do parágrafo. O exemplo a seguir atribui um tamanho de fonte e fonte latina à marca de fim do segundo parágrafo:

1. Carregue uma [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e acesse um slide.
2. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) e limpe seu parágrafo padrão.
3. Crie dois parágrafos e adicione porções de texto a eles.
4. Crie um [PortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/portionformat/) para a marca de fim do segundo parágrafo.
5. Defina [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseportionformat/set_fontheight/) e [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseportionformat/set_latinfont/).
6. Atribua o formato com [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) e salve a apresentação.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Importar e exportar conteúdo de parágrafos**

### **Importar texto HTML em parágrafos**

Use [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphcollection/addfromhtml/) para converter marcação HTML em parágrafos e porções dentro de um quadro de texto.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Acesse um slide e adicione um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/).
3. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da forma e limpe seu parágrafo padrão.
4. Leia o arquivo HTML de origem.
5. Passe a string HTML para [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphcollection/addfromhtml/).
6. Salve a apresentação modificada.

Este exemplo em C++ importa HTML para um quadro de texto:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Exportar texto de parágrafo para HTML**

Use [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphcollection/exporttohtml/) para exportar um intervalo selecionado de parágrafos como HTML.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) e carregue a apresentação desejada.
2. Acesse o slide e encontre o [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) que contém o texto.
3. Acesse o [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) da forma.
4. Chame [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphcollection/exporttohtml/) com o índice do parágrafo inicial e o número de parágrafos a exportar.
5. Escreva a string HTML retornada em um arquivo.

Este exemplo em C++ exporta todos os parágrafos da primeira forma de texto:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **Renderizar um parágrafo como imagem**

[IParagraph::GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/getimage/) renderiza diretamente um parágrafo individual e retorna um [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/). Salve o resultado em um arquivo ou fluxo com [IImage::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/save/). Não é necessário renderizar a forma contenedora ou recortar um bitmap manualmente.

[IParagraph::GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/getimage/) pode retornar `nullptr` se o parágrafo não for encontrado em sua coleção pai, não possuir limites de renderização válidos ou não puder ser renderizado. Verifique o resultado antes de salvá‑lo e libere a imagem retornada após o uso.

#### **Renderizar um parágrafo na escala padrão**

Suponha que temos um arquivo de apresentação chamado sample.pptx com um slide, onde a primeira forma é uma caixa de texto contendo três parágrafos.

![The text box with three paragraphs](paragraph_to_image_input.png)

O exemplo a seguir renderiza o segundo parágrafo em uma forma de texto regular na escala padrão e salva a imagem retornada em formato PNG.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

O resultado:

![The paragraph image](paragraph_to_image_output.png)

#### **Renderizar um parágrafo em célula de tabela com escalonamento**

Use a sobrecarga de [IParagraph::GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/getimage/) que aceita os parâmetros `float scaleX` e `float scaleY` para definir os fatores de escala horizontal e vertical. O exemplo a seguir cria uma tabela, renderiza o parágrafo em sua primeira célula com o dobro da largura e altura padrão e salva o resultado como imagem PNG.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

Um fator de escala `1` mantém esse eixo no tamanho de pixel padrão. Por exemplo, `2` para ambos os fatores produz uma imagem cuja largura e altura são aproximadamente o dobro das dimensões padrão, resultando em quatro vezes mais pixels. Fatores maiores geralmente produzem texto mais nítido para zoom ou saída de alta resolução, mas também aumentam o uso de memória e o tamanho do arquivo. Fatores abaixo de `1` geram imagens menores com menos detalhe. Use fatores iguais para preservar a proporção do parágrafo; fatores diferentes horizontal e verticalmente esticam a saída independentemente.

Renderizar uma forma inteira com [IShape::GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/getimage/) continua útil quando a saída deve incluir o preenchimento, borda ou outro contexto visual da forma. Para uma imagem contendo apenas o parágrafo, use [IParagraph::GetImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/getimage/).

## **Perguntas frequentes**

**Posso desativar completamente a quebra de linha dentro de um quadro de texto?**

Sim. Use [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/set_wraptext/) para desativar a quebra, de modo que as linhas não se interrompam nas bordas do quadro de texto.

**Como posso obter os limites exatos na tela de um parágrafo específico?**

Use [IParagraph::GetRect](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/getrect/) para recuperar o retângulo delimitador do parágrafo. [IPortion::GetRect](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportion/getrect/) fornece os limites de uma porção individual.

**Onde a alinhamento de parágrafo (esquerda, direita, centro ou justificado) é controlado?**

[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_alignment/) é uma configuração de nível de parágrafo e se aplica a todo o parágrafo, independentemente da formatação de cada porção.

**Posso definir o idioma de verificação para parte de um parágrafo?**

Sim. Use [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibaseportionformat/set_languageid/) para porções individuais, permitindo que um parágrafo contenha texto em vários idiomas.