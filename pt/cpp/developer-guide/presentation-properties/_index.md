---
title: Gerenciar Propriedades da Apresentação em C++
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/cpp/presentation-properties/
keywords:
- propriedades do PowerPoint
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
description: "Domine as propriedades da apresentação no Aspose.Slides para C++ e simplifique a pesquisa, a identidade visual e o fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides oferece dois tipos de propriedades de documento: **Integradas** e **Personalizadas**. Ambos os tipos de propriedade podem ser acessados e gerenciados facilmente usando a API do Aspose.Slides.

Aspose.Slides permite trabalhar com as propriedades do documento de apresentação através da interface [IDocumentProperties](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_document_properties). Uma instância dessa interface é devolvida pelo método [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_documentproperties/). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" %}} 
Observe que não é possível definir valores nos campos **Application** e **Producer**, porque “Aspose Ltd.” e “Aspose.Slides for C++ x.x.x” serão exibidos nesses campos.
{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint oferece um recurso para adicionar algumas propriedades aos arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas junto com os documentos (arquivos de apresentação). Existem dois tipos de propriedades de documento:

- Propriedades Definidas pelo Sistema (Integradas)
- Propriedades Definidas pelo Usuário (Personalizadas)

As propriedades **Integradas** contêm informações gerais sobre o documento, como título, nome do autor, estatísticas do documento etc. As propriedades **Personalizadas** são pares **Nome/Valor** definidos pelo usuário. Usando o Aspose.Slides for C++, os desenvolvedores podem acessar e modificar os valores das propriedades integradas bem como das personalizadas. O Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Basta clicar no ícone do Office e, em seguida, em **Preparar | Propriedades | Propriedades Avançadas** no Microsoft PowerPoint 2007. Após selecionar **Propriedades Avançadas**, uma caixa de diálogo será exibida permitindo gerenciar as propriedades do arquivo PowerPoint. Na **Caixa de Diálogo de Propriedades**, você verá várias abas, como **Geral, Resumo, Estatísticas, Conteúdo e Personalizado**. Todas essas abas permitem configurar diferentes tipos de informações relacionadas aos arquivos PowerPoint. A aba **Personalizado** é usada para gerenciar propriedades personalizadas dos arquivos PowerPoint.

## **Acessar Propriedades Integradas**

Essas propriedades, expostas pelo objeto **IDocumentProperties**, incluem: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **Keywords**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modificar Propriedades Integradas**

Modificar as propriedades integradas de arquivos de apresentação é tão simples quanto acessá‑las. Basta atribuir um valor string à propriedade desejada e o valor será alterado. No exemplo abaixo, demonstramos como modificar as propriedades integradas de um documento de apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Adicionar Propriedades Personalizadas à Apresentação**

Aspose.Slides for C++ também permite que os desenvolvedores adicionem valores personalizados às propriedades de documento da apresentação. O exemplo a seguir mostra como definir propriedades personalizadas para uma apresentação.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

## **Acessar e Modificar Propriedades Personalizadas**

Aspose.Slides for C++ ainda permite que os desenvolvedores acessem os valores das propriedades personalizadas. O exemplo a seguir demonstra como acessar e modificar todas essas propriedades personalizadas de uma apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Definir Idioma de Revisão**

Aspose.Slides fornece a propriedade [LanguageId](https://reference.aspose.com/slides/pt/cpp/aspose.slides.baseportionformat/set_languageid/) (exposta pela classe [PortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/portionformat/)) para permitir que você defina o idioma de revisão de um documento PowerPoint. O idioma de revisão é o idioma para o qual ortografia e gramática são verificados no PowerPoint.

Este código C++ mostra como definir o idioma de revisão para um PowerPoint:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
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

Este código C++ mostra como definir o idioma padrão para uma apresentação PowerPoint inteira:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Adiciona uma nova forma retangular com texto
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Verifica o idioma da primeira porção
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Exemplo Interativo**

Experimente o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API do Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## ***FAQ**

### Como remover uma propriedade integrada de uma apresentação?

Propriedades integradas são parte integrante da apresentação e não podem ser removidas completamente. Entretanto, você pode alterar seus valores ou defini‑las como vazias, se a propriedade permitir.

### O que acontece se eu adicionar uma propriedade personalizada que já existe?

Se você adicionar uma propriedade personalizada que já existe, seu valor atual será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade previamente, pois o Aspose.Slides atualiza o valor automaticamente.

### Posso acessar as propriedades da apresentação sem carregar a apresentação completa?

Sim. Você pode acessar as propriedades da apresentação sem carregá‑la completamente usando o método `GetPresentationInfo` da classe [PresentationFactory](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentationfactory/). Em seguida, utilize o método `ReadDocumentProperties` fornecido pela interface [IPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/) para ler as propriedades de forma eficiente, economizando memória e melhorando o desempenho.