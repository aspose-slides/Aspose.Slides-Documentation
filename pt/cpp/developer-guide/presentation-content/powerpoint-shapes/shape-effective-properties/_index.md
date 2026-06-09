---
title: Obter propriedades efetivas de forma de apresentações em C++
linktitle: Propriedades Efetivas
type: docs
weight: 50
url: /pt/cpp/shape-effective-properties/
keywords:
- propriedades de forma
- propriedades de câmera
- rig de luz
- forma chanfrada
- quadro de texto
- estilo de texto
- altura da fonte
- formato de preenchimento
- PowerPoint
- apresentação
- C++
- Aspose.Slides
description: "Descubra como o Aspose.Slides para C++ calcula e aplica propriedades efetivas de forma para renderização precisa do PowerPoint."
---
## **Visão geral**

Este tópico explica a diferença entre propriedades **locais** e **efetivas**. Valores locais são valores definidos diretamente em um nível específico de formatação, como:

1. Propriedades de porção em um slide.
1. Estilos de texto de forma protótipo em um layout ou slide mestre, quando a forma de quadro de texto da porção possui um.
1. Configurações globais de texto em uma apresentação.

Valores locais podem ser definidos ou omitidos em qualquer nível. Quando o Aspose.Slides precisa da formatação final “como renderizado”, ele resolve a cadeia de herança e retorna valores **efetivos**. Você pode obtê‑los chamando o método `GetEffective` no objeto de formatação local.

O exemplo a seguir mostra como obter valores efetivos. Ele supõe que a primeira forma no primeiro slide é um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) com um quadro de texto e ao menos uma porção.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}

Dados de formatação efetiva representam a formatação calculada atual após a aplicação da herança. Na implementação atual, alguns objetos de dados efetivos, como [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iportionformateffectivedata/), podem ser armazenados em cache internamente. Chamar `GetEffective` novamente após alterar a formatação do pai ou herdada pode atualizar o cache, e um objeto obtido anteriormente pode não representar o estado anterior. Se precisar preservar valores efetivos para reutilização posterior, copie as propriedades necessárias, como altura da fonte, cor de preenchimento, estilo da fonte ou alinhamento, para seu próprio objeto de dados.

{{% /alert %}}

## **Obter propriedades efetivas de uma câmera**

O Aspose.Slides permite obter propriedades efetivas de uma câmera. A interface [ICameraEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icameraeffectivedata/) representa um objeto imutável que contém propriedades efetivas da câmera. Uma instância de [ICameraEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icameraeffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/).

O código a seguir mostra como obter propriedades efetivas da câmera. Ele supõe que a primeira forma no primeiro slide possui formatação 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **Obter propriedades efetivas de um rig de luz**

O Aspose.Slides permite obter propriedades efetivas de um rig de luz. A interface [ILightRigEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilightrigeffectivedata/) representa um objeto imutável que contém propriedades efetivas do rig de luz. Uma instância de [ILightRigEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ilightrigeffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/).

O código a seguir mostra como obter propriedades efetivas do rig de luz. Ele supõe que a primeira forma no primeiro slide possui formatação 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **Obter propriedades efetivas de um chanfrado de forma**

O Aspose.Slides permite obter propriedades efetivas de um chanfrado de forma. A interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapebeveleffectivedata/) representa um objeto imutável que contém propriedades efetivas de relevo de face para uma forma. Uma instância de [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapebeveleffectivedata/) é exposta através de [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformateffectivedata/), que fornece valores efetivos para [IThreeDFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ithreedformat/).

O código a seguir mostra como obter propriedades efetivas do chanfrado superior de uma forma. Ele supõe que a primeira forma no primeiro slide possui formatação 3D.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **Obter propriedades efetivas de um quadro de texto**

Usando o Aspose.Slides, você pode obter propriedades efetivas de um quadro de texto. A interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframeformateffectivedata/) contém propriedades efetivas de formatação de quadro de texto.

O código a seguir mostra como obter propriedades efetivas de formatação de quadro de texto. Ele supõe que a primeira forma no primeiro slide é um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) com um quadro de texto.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **Obter propriedades efetivas de um estilo de texto**

Usando o Aspose.Slides, você pode obter propriedades efetivas de um estilo de texto. A interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextstyleeffectivedata/) contém propriedades efetivas de estilo de texto.

O código a seguir mostra como obter propriedades efetivas de estilo de texto. Ele supõe que a primeira forma no primeiro slide é um [IAutoShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iautoshape/) com um quadro de texto.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **Obter o valor efetivo da altura da fonte**

Usando o Aspose.Slides, você pode obter a altura da fonte efetiva. O código a seguir demonstra como a altura da fonte efetiva de uma porção muda após valores de altura de fonte locais serem definidos em diferentes níveis da estrutura da apresentação.

```cpp
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Obter o formato de preenchimento efetivo para uma tabela**

Usando o Aspose.Slides, você pode obter o preenchimento efetivo para diferentes partes de uma tabela. A interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ifillformateffectivedata/) contém propriedades efetivas de preenchimento. A formatação de célula tem prioridade mais alta que a formatação de linha, a formatação de linha tem prioridade mais alta que a formatação de coluna, e a formatação de coluna tem prioridade mais alta que a formatação de tabela completa.

Como resultado, as propriedades de [ICellFormatEffectiveData](https://reference.aspose.com/slides/pt/cpp/aspose.slides/icellformateffectivedata/) são usadas para desenhar a célula da tabela. O código a seguir mostra como obter o preenchimento efetivo para diferentes partes da tabela. Ele supõe que a primeira forma no primeiro slide é um [ITable](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itable/).

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **Perguntas frequentes**

**`GetEffective` retorna uma captura instantânea?**

Nem sempre. Dados efetivos representam a formatação calculada após a herança ser aplicada, mas alguns objetos de dados efetivos podem ser armazenados em cache internamente. Uma chamada subsequente a `GetEffective` pode recalcular a formatação e atualizar o cache, portanto um objeto obtido anteriormente não deve ser tratado como uma captura durável.

**Quando devo ler as propriedades efetivas novamente?**

Chame `GetEffective` novamente após alterar a formatação local, estilos de pai, formatação de layout, formatação mestre ou valores padrão da apresentação. A próxima chamada reavalia a hierarquia de formatação e retorna o resultado efetivo atual.

**Alterar ou remover um slide de layout/mestre afeta propriedades efetivas que já foram obtidas?**

Sim, mas a alteração só será refletida na próxima chamada a `GetEffective`. Se uma fonte de formatação pai for alterada ou removida, os dados efetivos obtidos anteriormente podem ficar desatualizados. Quando `GetEffective` for chamado novamente, o Aspose.Slides reavalia a árvore de formatação e as fontes, cores, tamanhos ou outros valores resultantes podem mudar.

**Posso modificar valores através de objetos de dados efetivos?**

Não. Objetos de dados efetivos expõem valores calculados. Faça alterações nos objetos de formatação local e, em seguida, obtenha os valores efetivos novamente.

**O que acontece se uma propriedade não estiver definida no nível da forma, nem no layout/mestre, nem nas configurações globais?**

O valor efetivo é determinado pelo mecanismo padrão, que inclui padrões do PowerPoint e do Aspose.Slides. Esse valor resolvido passa a fazer parte dos dados efetivos atuais.

**A partir de um valor de fonte efetivo, consigo saber qual nível forneceu o tamanho ou a família?**

Não diretamente. Dados efetivos retornam o valor final. Para descobrir a origem, verifique os valores locais na porção, parágrafo, quadro de texto e estilos de texto nos níveis de layout, mestre e apresentação para ver onde a primeira definição explícita aparece.

**Por que valores efetivos às vezes são idênticos aos locais?**

Porque o valor local acabou sendo o final (não foi necessária herança de nível superior). Nesses casos, o valor efetivo coincide com o local.

**Quando devo usar propriedades efetivas e quando devo trabalhar apenas com as locais?**

Use dados efetivos quando precisar do resultado “como renderizado” após toda a herança ser aplicada, por exemplo, para alinhar cores, recuos ou tamanhos. Se precisar preservar esses valores independentemente de alterações de formatação posteriores, copie as propriedades necessárias para seu próprio objeto. Se precisar alterar a formatação em um nível específico, modifique as propriedades locais e, se necessário, leia os dados efetivos novamente para verificar o resultado.