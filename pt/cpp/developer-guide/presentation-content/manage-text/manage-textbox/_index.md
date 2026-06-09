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
- adicionar hyperlink
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ facilita a criação, edição e clonagem de caixas de texto em arquivos PowerPoint e OpenDocument, aprimorando a automação de suas apresentações."
---
## **Introdução**

Os textos em slides normalmente existem em caixas de texto ou formas. Portanto, para adicionar texto a um slide, você precisa adicionar uma caixa de texto e então colocar algum texto dentro da caixa. Aspose.Slides for C++ fornece a interface [IAutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape) que permite adicionar uma forma contendo texto.

{{% alert title="Info" color="info" %}}
Aspose.Slides também fornece a interface [IShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_shape) que permite adicionar formas aos slides. Contudo, nem todas as formas adicionadas através da interface `IShape` podem conter texto. Mas as formas adicionadas através da interface [IAutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape) podem conter texto. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Portanto, ao lidar com uma forma à qual você deseja adicionar texto, pode ser necessário verificar e confirmar que ela foi convertida através da interface `IAutoShape`. Só então você poderá trabalhar com [TextFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.text_frame), que é uma propriedade de `IAutoShape`. Consulte a seção [Update Text](https://docs.aspose.com/slides/pt/cpp/manage-textbox/#update-text) nesta página. 
{{% /alert %}}

## **Criar uma Caixa de Texto em um Slide**

Para criar uma caixa de texto em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation). 
2. Obtenha uma referência para o primeiro slide da apresentação recém‑criada. 
3. Adicione um objeto [IAutoShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_auto_shape) com [ShapeType](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) definido como `Rectangle` em uma posição especificada no slide e obtenha a referência para o objeto `IAutoShape` recém‑adicionado. 
4. Adicione a propriedade `TextFrame` ao objeto `IAutoShape` que conterá texto. No exemplo abaixo, adicionamos este texto: *Aspose TextBox*
5. Finalmente, grave o arquivo PPTX através do objeto `Presentation`. 

Este código C++ — uma implementação dos passos acima — mostra como adicionar texto a um slide:

```cpp
// Instancia a Presentation
// Obtém o primeiro slide da apresentação
// Adiciona um AutoShape com o tipo definido como Rectangle
// Adiciona TextFrame ao retângulo
// Acessa o quadro de texto
// Cria o objeto Paragraph para o quadro de texto
// Cria um objeto Portion para o parágrafo
// Define o texto
// Salva a apresentação no disco
auto pres = System::MakeObject<Presentation>();
auto sld = pres->get_Slides()->idx_get(0);
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);
ashp->AddTextFrame(u" ");
auto txtFrame = ashp->get_TextFrame();
auto para = txtFrame->get_Paragraphs()->idx_get(0);
auto portion = para->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Verificar se uma Forma é Caixa de Texto**

Aspose.Slides fornece o método [get_IsTextBox](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/get_istextbox/) da interface [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) que permite examinar formas e identificar caixas de texto.

![Caixa de texto e forma](istextbox.png)

Este código C++ mostra como verificar se uma forma foi criada como caixa de texto: 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Observe que se você simplesmente adicionar uma autoshape usando o método `AddAutoShape` da interface [IShapeCollection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/) , o método `get_IsTextBox` da autoshape retornará `false`. Contudo, depois de adicionar texto à autoshape usando o método `AddTextFrame` ou o método `set_Text`, o método `get_IsTextBox` retornará `true`.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() retorna false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() retorna true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() retorna false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() retorna true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() retorna false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() retorna false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() retorna false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() retorna false
```

## **Adicionar Colunas a uma Caixa de Texto**

Aspose.Slides fornece os métodos [set_ColumnCount](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) e [set_ColumnSpacing](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (da interface [ITextFrameFormat](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_text_frame_format) e da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_text_frame_format)) que permitem adicionar colunas a caixas de texto. Você pode especificar o número de colunas em uma caixa de texto e definir o espaçamento entre colunas em pontos. 

Este código em C++ demonstra a operação descrita: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// Obtém o primeiro slide da apresentação
auto slide = presentation->get_Slides()->idx_get(0);

// Adiciona um AutoShape com o tipo definido como Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Adiciona TextFrame ao retângulo
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Obtém o formato de texto do TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Especifica o número de colunas no TextFrame
format->set_ColumnCount(3);

// Especifica o espaçamento entre colunas
format->set_ColumnSpacing(10);

// Salva a apresentação
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Adicionar Colunas a um Quadro de Texto**
Aspose.Slides for C++ fornece o método [set_ColumnCount](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (da interface [ITextFrameFormat](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_text_frame_format)) que permite adicionar colunas em quadros de texto. Através deste método, você pode especificar o número desejado de colunas em um quadro de texto. 

Este código C++ mostra como adicionar uma coluna dentro de um quadro de texto:

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Atualizar Texto**

Aspose.Slides permite mudar ou atualizar o texto contido em uma caixa de texto ou todo o texto contido em uma apresentação. 

Este código C++ demonstra uma operação onde todo o texto de uma apresentação é atualizado ou alterado:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //Altera o texto
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Altera a formatação
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Salva a apresentação modificada
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Adicionar uma Caixa de Texto com Hyperlink** 

Você pode inserir um link dentro de uma caixa de texto. Quando a caixa de texto for clicada, os usuários são direcionados para abrir o link. 

Para adicionar uma caixa de texto contendo um link, siga estes passos:

1. Crie uma instância da classe `Presentation`. 
2. Obtenha uma referência para o primeiro slide da apresentação recém‑criada. 
3. Adicione um objeto `AutoShape` com `ShapeType` definido como `Rectangle` em uma posição especificada no slide e obtenha a referência do objeto AutoShape recém‑adicionado.
4. Adicione um `TextFrame` ao objeto `AutoShape` que contenha *Aspose TextBox* como texto padrão. 
5. Instancie a classe `IHyperlinkManager`. 
6. Atribua o objeto `IHyperlinkManager` ao método [set_HyperlinkClick](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) associado à sua parte preferida do `TextFrame`. 
7. Finalmente, grave o arquivo PPTX através do objeto `Presentation`. 

Este código C++ — uma implementação dos passos acima — mostra como adicionar uma caixa de texto com hyperlink a um slide:

```cpp
// Instancia uma classe Presentation que representa um PPTX
auto presentation = System::MakeObject<Presentation>();

// Obtém o primeiro slide da apresentação
auto slide = presentation->get_Slides()->idx_get(0);

// Adiciona um objeto AutoShape com o tipo definido como Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Converte a forma para AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Acessa a propriedade ITextFrame associada ao AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Adiciona algum texto ao quadro
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Define o Hyperlink para o texto da porção
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Salva a apresentação PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Qual a diferença entre uma caixa de texto e um placeholder de texto ao trabalhar com slides mestres?**

Um [placeholder](/slides/pt/cpp/manage-placeholder/) herda estilo/posição do [master](https://reference.aspose.com/slides/pt/cpp/aspose.slides/masterslide/) e pode ser sobrescrito nos [layouts](https://reference.aspose.com/slides/pt/cpp/aspose.slides/layoutslide/), enquanto uma caixa de texto regular é um objeto independente em um slide específico e não muda quando você troca de layout.

**Como posso realizar uma substituição em massa de texto em toda a apresentação sem alterar o texto dentro de gráficos, tabelas e SmartArt?**

Limite sua iteração às auto‑shapes que possuam quadros de texto e exclua objetos incorporados ([charts](https://reference.aspose.com/slides/pt/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/pt/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pt/cpp/aspose.slides.smartart/smartart/)) percorrendo suas coleções separadamente ou ignorando esses tipos de objeto.