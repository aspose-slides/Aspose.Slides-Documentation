---
title: Gerenciar Propriedades da Apresentação em C++
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/cpp/presentation-properties/
keywords:
- Propriedades do PowerPoint
- Propriedades da apresentação
- Propriedades do documento
- Propriedades integradas
- Propriedades personalizadas
- Propriedades avançadas
- Gerenciar propriedades
- Modificar propriedades
- Metadados do documento
- Editar metadados
- Idioma de revisão
- Idioma padrão
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides para C++ e simplifique a pesquisa, a identidade visual e o fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides oferece suporte a dois tipos de propriedades de documento: **Integradas** e **Personalizadas**. Ambos os tipos de propriedades podem ser facilmente acessados e gerenciados usando a API Aspose.Slides.

Aspose.Slides permite que você trabalhe com as propriedades de documentos de apresentação por meio da interface [IDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/idocumentproperties/). Uma instância dessa interface é retornada por [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_documentproperties/). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Nota" %}}

Observe que não é possível definir valores nos campos **Application** e **Producer**, pois Aspose Ltd. e Aspose.Slides for C++ x.x.x serão exibidos nesses campos.

{{% /alert %}} 

## **Gerenciar Propriedades da Apresentação**

O Microsoft PowerPoint fornece um recurso para adicionar algumas propriedades aos arquivos de apresentação. Essas propriedades de documento permitem que informações úteis sejam armazenadas junto aos documentos (arquivos de apresentação). Existem dois tipos de propriedades de documento conforme a seguir:

- Propriedades Definidas pelo Sistema (Integradas)
- Propriedades Definidas pelo Usuário (Personalizadas)

As propriedades **Integradas** contêm informações gerais sobre o documento, como título, nome do autor, estatísticas do documento etc. As propriedades **Personalizadas** são aquelas definidas pelos usuários como pares **Nome/Valor**, onde tanto o nome quanto o valor são definidos pelo usuário. Usando Aspose.Slides for C++, os desenvolvedores podem acessar e modificar os valores de propriedades integradas assim como de propriedades personalizadas. O Microsoft PowerPoint 2007 permite o gerenciamento das propriedades de documento dos arquivos de apresentação. Tudo o que você precisa fazer é clicar no ícone Office e, em seguida, no item de menu **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007. Ao selecionar o item de menu **Advanced Properties**, aparecerá uma caixa de diálogo que permite gerenciar as propriedades de documento do arquivo PowerPoint. Na **Caixa de Diálogo Propriedades**, você pode observar várias guias como **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Todas essas guias permitem configurar diferentes tipos de informações relacionadas aos arquivos PowerPoint. A guia **Custom** é usada para gerenciar propriedades personalizadas dos arquivos PowerPoint.

## **Ler Propriedades Públicas de uma Apresentação Criptografada**

Uma senha de abertura normalmente protege tanto o conteúdo da apresentação quanto as propriedades do documento. Quando uma apresentação é criptografada passando `false` para [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), suas propriedades de documento permanecem públicas. Uma aplicação pode então passar `true` para [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) e ler os metadados públicos sem fornecer a senha de abertura.

`set_OnlyLoadDocumentProperties` controla o que Aspose.Slides carrega; ele não descriptografa nada. Se as propriedades foram incluídas na criptografia, carregá‑las sem a senha falha. Se a apresentação não estiver criptografada, a opção é ignorada e a apresentação completa é carregada.

O exemplo a seguir verifica o modo de carregamento por meio de [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) e, em seguida, lê as propriedades integradas por meio de [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

Nesse modo, o conteúdo dos slides não é carregado. Slides, masters, layouts, shapes, mídia e outros objetos da apresentação ficam indisponíveis. As aplicações devem sempre verificar `get_IsOnlyDocumentPropertiesLoaded` antes de executar uma operação que exija o modelo completo de objetos da apresentação.

{{% alert color="warning" title="Aviso" %}}
Metadados públicos podem expor nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores personalizados. Criptografe propriedades sensíveis juntamente com a apresentação. Deixe‑as públicas apenas quando sistemas de indexação, classificação, pesquisa ou gerenciamento de documentos tiverem um requisito específico para acessá‑las sem senha.
{{% /alert %}}

## **Atualizar Propriedades de uma Apresentação Criptografada**

Para um arquivo PPTX criptografado, uma apresentação carregada após chamar `set_OnlyLoadDocumentProperties(true)` destina‑se à leitura de metadados públicos. Aspose.Slides não pode salvar as propriedades alteradas desse objeto somente‑metadados porque as propriedades públicas devem permanecer consistentes com os dados correspondentes dentro da apresentação criptografada. Atualizá‑las, portanto, requer a senha de abertura correta e um carregamento completo.

O exemplo a seguir abre a apresentação com [LoadOptions::set_Password](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_password/), atualiza as propriedades integradas públicas e salva o resultado. Em seguida, usa [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) para verificar se a criptografia foi preservada e reabre os metadados públicos sem senha para confirmar os novos valores:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Se uma aplicação não estiver autorizada a descriptografar ou carregar o conteúdo da apresentação, ela deve tratar as propriedades públicas de um arquivo PPTX criptografado como somente‑leitura.

## **Acessar Propriedades Integradas**

Essas propriedades expostas pelo objeto **IDocumentProperties** incluem: **Creator(Author)**, **Description**, **KeyWords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **Keywords**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modificar Propriedades Integradas**

Modificar as propriedades integradas de arquivos de apresentação é tão simples quanto acessá‑las. Você pode simplesmente atribuir um valor string a qualquer propriedade desejada e o valor será alterado. No exemplo abaixo, demonstramos como modificar as propriedades de documento integradas do arquivo de apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Adicionar Propriedades Personalizadas à Apresentação**

Aspose.Slides for C++ também permite que os desenvolvedores adicionem valores personalizados às propriedades de documento da apresentação. O exemplo a seguir mostra como definir propriedades personalizadas para uma apresentação.

``` cpp
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

Aspose.Slides for C++ também permite que os desenvolvedores acessem os valores das propriedades personalizadas. O exemplo a seguir mostra como você pode acessar e modificar todas essas propriedades personalizadas de uma apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Definir Idioma de Revisão**

Aspose.Slides fornece a propriedade [LanguageId](https://reference.aspose.com/slides/pt/cpp/aspose.slides/baseportionformat/set_languageid/) (exposta pela classe [PortionFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/portionformat/)) para permitir que você defina o idioma de revisão para um documento PowerPoint. O idioma de revisão é o idioma para o qual a ortografia e a gramática no PowerPoint são verificadas.

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

Este código C++ mostra como definir o idioma padrão para toda a apresentação PowerPoint:

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

Experimente o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **Perguntas Frequentes**

**Como posso remover uma propriedade integrada de uma apresentação?**

Propriedades integradas são parte integrante da apresentação e não podem ser removidas completamente. No entanto, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, o valor existente será sobrescrito pelo novo valor. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar propriedades da apresentação sem carregar a apresentação completa?**

Sim. Use [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) e depois [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) para ler os metadados armazenados do documento sem criar uma instância [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/pt/cpp/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.

**Posso ler propriedades públicas de uma apresentação criptografada sem sua senha de abertura?**

Sim. A apresentação deve ter sido criptografada passando `false` para `set_EncryptDocumentProperties` e deve ser carregada passando `true` para `set_OnlyLoadDocumentProperties`.

**Posso atualizar um arquivo PPTX criptografado no modo somente‑propriedades‑de‑documento?**

Não. Dados de propriedades públicas e criptografadas devem permanecer consistentes, portanto, atualizar um arquivo PPTX criptografado requer o carregamento completo da apresentação com a senha de abertura correta.