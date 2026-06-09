---
title: Melhore suas Apresentações com AutoFit em C++
linktitle: Configurações de Autofit
type: docs
weight: 30
url: /pt/cpp/manage-autofit-settings/
keywords:
- caixa de texto
- ajuste automático
- não autofit
- ajustar texto
- reduzir texto
- quebrar texto
- redimensionar forma
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda como gerenciar as configurações de AutoFit no Aspose.Slides para C++ para otimizar a exibição de texto em suas apresentações PowerPoint e OpenDocument e melhorar a legibilidade do conteúdo."
---
## **Introdução**

Por padrão, ao inserir uma caixa de texto, o Microsoft PowerPoint usa a configuração **Resize shape to fix text** para a caixa de texto—ele redimensiona automaticamente a caixa de texto para garantir que seu conteúdo sempre caiba nela. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Quando o texto na caixa de texto se torna mais longo ou maior, o PowerPoint aumenta automaticamente a caixa de texto—aumenta sua altura—para permitir que mais texto seja exibido. 
* Quando o texto na caixa de texto se torna mais curto ou menor, o PowerPoint reduz automaticamente a caixa de texto—diminui sua altura—para eliminar espaço redundante. 

No PowerPoint, estes são os 4 parâmetros ou opções importantes que controlam o comportamento de autofit para uma caixa de texto: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

O Aspose.Slides for C++ oferece opções semelhantes—alguns métodos da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.text_frame_format)—que permitem controlar o comportamento de autofit para caixas de texto em apresentações. 

## **Resize a Shape to Fit Text**

Se você deseja que o texto em uma caixa sempre caiba nela após alterações no conteúdo, deve usar a opção **Resize shape to fix text**. Para especificar essa configuração, defina a propriedade [AutofitType](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.text_frame_format)) como `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Este código C++ mostra como especificar que um texto deve sempre caber em sua caixa em uma apresentação PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Se o texto ficar mais longo ou maior, a caixa de texto será redimensionada automaticamente (aumentando a altura) para garantir que todo o texto caiba. Se o texto ficar mais curto, o processo inverso ocorrerá. 

## **Do Not Autofit**

Se você quer que uma caixa de texto ou forma mantenha suas dimensões independentemente das alterações no texto que contém, deve usar a opção **Do not Autofit**. Para especificar essa configuração, defina a propriedade [AutofitType](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.text_frame_format)) como `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Este código C++ mostra como especificar que uma caixa de texto deve sempre manter suas dimensões em uma apresentação PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Quando o texto fica muito longo para a caixa, ele transborda. 

## **Shrink Text on Overflow**

Se um texto ficar muito longo para a caixa, usando a opção **Shrink text on overflow** você pode especificar que o tamanho e o espaçamento do texto devem ser reduzidos para que ele caiba na caixa. Para especificar essa configuração, defina a propriedade [AutofitType](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.text_frame_format)) como `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Este código C++ mostra como especificar que um texto deve ser reduzido quando houver transbordamento em uma apresentação PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}
Ao usar a opção **Shrink text on overflow**, a configuração é aplicada somente quando o texto fica muito longo para a caixa. 
{{% /alert %}}

## **Wrap Text**

Se você deseja que o texto em uma forma seja quebrado dentro dela quando ultrapassar a borda da forma (apenas a largura), deve usar o parâmetro **Wrap text in shape**. Para especificar essa configuração, defina a propriedade [WrapText](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (da classe [TextFrameFormat](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.text_frame_format)) como `true`. 

Este código C++ mostra como usar a configuração Wrap Text em uma apresentação PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Se você definir a propriedade `WrapText` como `False` para uma forma, quando o texto dentro da forma ficar mais longo que a largura da forma, o texto se estenderá além das bordas da forma em uma única linha. 
{{% /alert %}}

## **Perguntas Frequentes**

**As margens internas do quadro de texto afetam o AutoFit?**

Sim. O preenchimento (margens internas) reduz a área utilizável para o texto, fazendo com que o AutoFit seja acionado mais cedo—encolhendo a fonte ou redimensionando a forma mais rapidamente. Verifique e ajuste as margens antes de afinar o AutoFit.

**Como o AutoFit interage com quebras de linha manuais e suaves?**

Quebras forçadas permanecem no lugar, e o AutoFit adapta o tamanho da fonte e o espaçamento em torno delas. Remover quebras desnecessárias costuma reduzir a agressividade com que o AutoFit precisa encolher o texto.

**Alterar a fonte do tema ou acionar substituição de fonte influencia os resultados do AutoFit?**

Sim. Substituir por uma fonte com métricas de glifo diferentes altera a largura/altura do texto, podendo mudar o tamanho final da fonte e a quebra de linha. Após qualquer mudança ou substituição de fonte, reveja os slides.