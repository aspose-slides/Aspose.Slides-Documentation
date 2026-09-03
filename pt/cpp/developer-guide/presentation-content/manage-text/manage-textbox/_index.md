---
title: Gerenciar caixas de texto em apresentações usando C++
linktitle: Gerenciar caixa de texto
type: docs
weight: 20
url: /pt/cpp/manage-textbox/
keywords:
- caixa de texto
- quadro de texto
- adicionar texto
- atualizar texto
- criar caixa de texto
- verificar caixa de texto
- adicionar coluna de texto
- adicionar hiperlink
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Criar, identificar, formatar e atualizar caixas de texto em apresentações PowerPoint e OpenDocument usando Aspose.Slides para C++."
---
## **Introdução**

No Aspose.Slides for C++, o texto dos slides é armazenado em quadros de texto que pertencem a formas. A interface [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) representa a forma mais comum que contém texto e expõe seu texto através do método [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/get_textframe/).

{{% alert color="info" title="Nota" %}}

Cada forma automática implementa [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/), mas nem toda forma é uma forma automática ou suporta um quadro de texto. Ao processar uma apresentação existente, verifique se uma forma implementa [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) antes de acessar seu texto.

{{% /alert %}}

## **Criar uma caixa de texto em um slide**

Para criar uma caixa de texto, adicione uma forma automática a um slide, adicione texto ao seu quadro de texto e salve a apresentação. O exemplo a seguir cria uma caixa de texto retangular:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

As coordenadas e dimensões passadas para [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addautoshape/) são medidas em pontos. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/addtextframe/) inicializa o quadro de texto com o texto fornecido.

## **Verificar se a forma é uma caixa de texto**

Use o método [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/get_istextbox/) para determinar se uma forma automática é tratada como uma caixa de texto. Isso é útil quando uma apresentação contém tanto formas automáticas que contêm texto quanto formas puramente gráficas.

![Uma caixa de texto e uma forma](istextbox.png)

O exemplo a seguir inspeciona cada forma automática em uma apresentação:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

Uma forma automática recém‑adicionada não é considerada uma caixa de texto até que contenha texto não vazio. Você pode fornecer esse texto através de [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/addtextframe/) ou [ITextFrame::set_Text](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/set_text/). Adicionar ou atribuir uma string vazia faz com que [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/get_istextbox/) retorne `false`:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

As duas primeiras verificações retornam `true`; as duas últimas retornam `false`.

## **Encontrar a forma que possui um quadro de texto**

Um código genérico de processamento de texto pode receber um [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) sem saber qual objeto da apresentação o contém. Use o método [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/get_parentshape/) para navegar de volta à sua forma proprietária [IShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishape/).

Para um quadro de texto que é propriedade de uma forma automática ou outra forma que contém texto, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/get_parentshape/) retorna o proprietário e [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/get_parentcell/) retorna `nullptr`. Ambos os métodos fornecem navegação somente leitura. Verifique o valor retornado por `nullptr` antes de acessá‑lo. Para identificar tanto proprietários de forma quanto de célula de tabela, incluindo formas associadas a nós de SmartArt, veja [Search and Replace Text](/slides/pt/cpp/search-and-replace-text/).

## **Adicionar colunas a uma caixa de texto**

O método [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/set_columncount/) divide o quadro de texto em colunas, enquanto [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/set_columnspacing/) define o espaço entre as colunas em pontos. Ambos os métodos pertencem a [ITextFrameFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/) e podem ser chamados através do quadro de texto de uma caixa de texto existente. O texto refaz a disposição entre colunas dentro da mesma forma; não continua em outra forma.

O exemplo a seguir cria uma caixa de texto de três colunas com 10 pontos entre as colunas, salva a apresentação e lê as configurações armazenadas de volta a partir do arquivo de saída:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Extrair texto de colunas individuais**

Use [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/splittextbycolumns/) para recuperar o texto atribuído a cada coluna visual em um quadro de texto existente. O método retorna uma string para cada coluna, na ordem de leitura baseada em colunas. Um quadro de texto de única coluna produz um array com um elemento, e uma coluna vazia é representada por uma string vazia. As strings contêm apenas texto simples; a formatação em nível de porções não é preservada.

Isso é útil quando você precisa:

- Extrair texto preservando sua ordem de leitura baseada em colunas.
- Indexar ou comparar o conteúdo de slides com múltiplas colunas.
- Exportar cada coluna para um arquivo separado, campo de banco de dados ou outro destino.
- Inspecionar como o texto é redistribuído após definir a contagem de colunas com [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/set_columncount/) ou o espaçamento com [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformat/set_columnspacing/), ou ao alterar a fonte ou o tamanho do quadro de texto.

O método relata o texto distribuído dentro do [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) atual; ele não flui automaticamente o texto entre formas ou caixas de texto separadas. A distribuição de colunas pode depender de fontes disponíveis e outras configurações de layout de texto, portanto certifique‑se de que as fontes necessárias estejam disponíveis quando resultados consistentes forem importantes.

O exemplo a seguir carrega uma apresentação, encontra a primeira forma automática de múltiplas colunas com um quadro de texto no primeiro slide, lê sua contagem de colunas configurada e grava o texto de cada coluna em um arquivo separado. Formas que não fornecem um quadro de texto são ignoradas.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Atualizar texto**

Para atualizar texto em toda a apresentação, itere pelos slides e formas, selecione formas automáticas e então edite suas porções de texto. Trabalhar no nível de porções permite modificar tanto o texto quanto a formatação de caracteres.

O exemplo a seguir substitui cada ocorrência de `years` por `months` dentro das porções de texto de formas automáticas individuais e torna cada porção afetada em negrito:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Esta travessia atualiza texto apenas em formas automáticas. Texto armazenado em tabelas, gráficos, SmartArt ou formas agrupadas requer a travessia das próprias coleções desses objetos.

## **Adicionar uma caixa de texto com hiperlink**

Um hiperlink pode ser atribuído a uma porção de texto específica, de modo que somente esse texto funcione como link clicável. Use [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) para associar a porção a uma URL externa.

O exemplo a seguir cria texto vinculado e o salva em uma apresentação:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Qual é a diferença entre uma caixa de texto e um marcador de posição de texto em um slide mestre ou de layout?**

Um [placeholder](/slides/pt/cpp/manage-placeholder/) pode herdar sua posição e formatação de um [master slide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/masterslide/) ou de um [layout slide](https://reference.aspose.com/slides/pt/cpp/aspose.slides/layoutslide/). Uma caixa de texto regular é uma forma independente no slide onde foi criada e não adquire o comportamento de marcador de posição quando o layout é alterado.

**Como posso substituir texto sem alterar o texto em gráficos, tabelas ou SmartArt?**

Limite a travessia às formas que implementam [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/), como mostrado no exemplo Atualizar Texto. Gráficos, tabelas e SmartArt armazenam texto em seus próprios modelos de objeto, portanto não são modificados por esse laço.