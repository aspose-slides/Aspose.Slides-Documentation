---
title: Gerenciar Propriedades da Apresentação em C++
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/cpp/presentation-properties/
keywords:
- Propriedades do PowerPoint
- propriedades da apresentação
- propriedades do documento
- propriedades integradas
- propriedades personalizadas
- propriedades avançadas
- gerenciar propriedades
- modificar propriedades
- metadados do documento
- editar metadados
- idioma de revisão
- idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides for C++ e simplifique a pesquisa, a identidade visual e o fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides suporta dois tipos de propriedades de documento: **Built-in** e **Custom**. Ambos os tipos de propriedades podem ser acessados e gerenciados facilmente usando a API do Aspose.Slides.

Aspose.Slides permite que você trabalhe com as propriedades de documento da apresentação através da interface [IDocumentProperties](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_document_properties). Uma instância dessa interface é retornada pelo método [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_documentproperties/). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="primary" %}} 

Observe que você não pode definir valores nos campos **Application** e **Producer**, pois Aspose Ltd. e Aspose.Slides for C++ x.x.x serão exibidos nesses campos.

{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint fornece um recurso para adicionar algumas propriedades aos arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas juntamente com os documentos (arquivos de apresentação). Existem dois tipos de propriedades de documento, conforme descrito a seguir:

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

As propriedades **Built-in** contêm informações gerais sobre o documento, como título do documento, nome do autor, estatísticas do documento etc. As propriedades **Custom** são aquelas definidas pelos usuários como pares **Nome/Valor**, onde tanto o nome quanto o valor são definidos pelo usuário. Usando Aspose.Slides for C++, os desenvolvedores podem acessar e modificar os valores das propriedades built-in assim como das propriedades custom. O Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Basta clicar no ícone do Office e, em seguida, selecionar **Prepare | Properties | Advanced Properties** no menu do Microsoft PowerPoint 2007. Depois de selecionar o item de menu **Advanced Properties**, aparecerá uma caixa de diálogo que permite gerenciar as propriedades de documento do arquivo PowerPoint. Na **Properties Dialog**, você verá várias páginas de abas, como **General, Summary, Statistics, Contents e Custom**. Todas essas páginas permitem configurar diferentes tipos de informações relacionadas aos arquivos PowerPoint. A aba **Custom** é usada para gerenciar propriedades custom dos arquivos PowerPoint.

## **Acessar Propriedades Built-in**

Essas propriedades expostas pelo objeto **IDocumentProperties** incluem: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **Keywords**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modificar Propriedades Built-in**

Modificar as propriedades built-in de arquivos de apresentação é tão simples quanto acessá‑las. Você pode simplesmente atribuir um valor de string a qualquer propriedade desejada e o valor da propriedade será modificado. No exemplo abaixo, demonstramos como modificar as propriedades built-in de documento do arquivo de apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Adicionar Propriedades Custom da Apresentação**

Aspose.Slides for C++ também permite que os desenvolvedores adicionem valores custom às propriedades de documento da apresentação. Abaixo há um exemplo que mostra como definir as propriedades custom para uma apresentação.

``` cpp
// Instanciar a classe Presentation
auto presentation = System::MakeObject<Presentation>();

// Obtendo propriedades do documento
auto documentProperties = presentation->get_DocumentProperties();

// Adicionando propriedades personalizadas
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Obtendo o nome da propriedade em um índice específico
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Removendo a propriedade selecionada
documentProperties->RemoveCustomProperty(getPropertyName);

// Salvando a apresentação
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Acessar e Modificar Propriedades Custom**

Aspose.Slides for C++ também permite que os desenvolvedores acessem os valores das propriedades custom. Abaixo há um exemplo que mostra como você pode acessar e modificar todas essas propriedades custom de uma apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Definir Idioma de Revisão**

Aspose.Slides fornece a propriedade [LanguageId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_languageid/) (exposta pela classe [PortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/portionformat/)) para permitir que você defina o idioma de revisão para um documento PowerPoint. O idioma de revisão é o idioma para o qual a ortografia e a gramática no PowerPoint são verificadas.

Este código C++ mostra como definir o idioma de revisão para um PowerPoint:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// definir o Id de um idioma de revisão

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Definir Idioma Padrão**

Este código C++ mostra como definir o idioma padrão para toda a apresentação PowerPoint:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Adiciona uma nova forma de retângulo com texto
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Verifica o idioma da primeira porção
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Exemplo ao Vivo**

Teste o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API do Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## ***FAQ**

**Como posso remover uma propriedade built-in de uma apresentação?**

Propriedades built-in são parte integrante da apresentação e não podem ser removidas completamente. Entretanto, você pode alterar seus valores ou defini‑las como vazias, caso a propriedade específica permita.

**O que acontece se eu adicionar uma propriedade custom que já existe?**

Se você adicionar uma propriedade custom que já existe, seu valor atual será sobrescrito pelo novo valor. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar a apresentação completamente?**

Sim, você pode acessar as propriedades da apresentação sem carregá‑la totalmente usando o método `GetPresentationInfo` da classe [PresentationFactory](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentationfactory/). Em seguida, utilize o método `ReadDocumentProperties` fornecido pela interface [IPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/) para ler as propriedades de forma eficiente, economizando memória e melhorando o desempenho.