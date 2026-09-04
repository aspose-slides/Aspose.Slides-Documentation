---
title: Gerenciar Propriedades da Apresentação em Java
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/java/presentation-properties/
keywords:
- Propriedades do PowerPoint
- Propriedades da apresentação
- Propriedades do documento
- Propriedades incorporadas
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
- Java
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides para Java e simplifique a pesquisa, a identidade visual e o fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides suporta dois tipos de propriedades de documento: **Built-in** e **Custom**. Ambos os tipos de propriedades podem ser acessados e gerenciados facilmente usando a API do Aspose.Slides.

Aspose.Slides permite que você trabalhe com propriedades de documentos de apresentação através da interface [IDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties/). Uma instância dessa interface é retornada por [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Note" %}}
Observe que os campos **Application** e **AppVersion** não podem ser modificados. Aspose.Slides os reescreve a cada gravação, de modo que uma apresentação salva sempre informa "Aspose.Slides for Java" e a versão da biblioteca que a gerou. Qualquer valor passado para `setNameOfApplication` é descartado quando a apresentação é gravada.
{{% /alert %}} 

## **Propriedades de Documento no PowerPoint**

Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Tudo o que você precisa fazer é clicar no ícone do Office e, em seguida, no item de menu **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007, como mostrado abaixo:

|**Selecionar item de menu Propriedades Avançadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Depois de selecionar o item de menu **Advanced Properties**, uma caixa de diálogo aparecerá permitindo que você gerencie as propriedades de documento do arquivo PowerPoint, conforme mostrado na figura abaixo:

|**Caixa de Diálogo de Propriedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Na **Caixa de Diálogo de Propriedades** acima, você pode ver que há várias abas como **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Todas essas abas permitem configurar diferentes tipos de informações relacionadas aos arquivos PowerPoint. A aba **Custom** é usada para gerenciar as propriedades personalizadas dos arquivos PowerPoint.

### Trabalhando com Propriedades de Documento usando Aspose.Slides para Java

Como descrito anteriormente, Aspose.Slides para Java suporta dois tipos de propriedades de documento, que são **Built-in** e **Custom**. Portanto, os desenvolvedores podem acessar ambos os tipos de propriedades usando a API do Aspose.Slides para Java. Aspose.Slides para Java fornece a classe [IDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties) que representa as propriedades de documento associadas a um arquivo de apresentação através da propriedade **Presentation.DocumentProperties**.

Os desenvolvedores podem usar a propriedade **IDocumentProperties** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation) para acessar as propriedades de documento dos arquivos de apresentação, conforme descrito abaixo:

## **Ler Propriedades Públicas de uma Apresentação Criptografada**

Uma senha de abertura normalmente protege tanto o conteúdo da apresentação quanto as propriedades de documento. Quando uma apresentação é criptografada passando `false` para [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), suas propriedades de documento permanecem públicas. Uma aplicação pode então passar `true` para [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) e ler os metadados públicos sem fornecer a senha de abertura.

A opção somente‑document‑properties controla o que o Aspose.Slides carrega; ela não descriptografa nada. Se as propriedades foram incluídas na criptografia, carregá‑las sem a senha falha. Se a apresentação não estiver criptografada, a opção é ignorada e a apresentação completa é carregada.

O exemplo a seguir verifica o modo de carregamento através de [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) e, em seguida, lê as propriedades incorporadas através de [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Nesse modo, o conteúdo dos slides não é carregado. Slides, mestres, layouts, formas, mídia e outros objetos da apresentação ficam indisponíveis. As aplicações devem sempre verificar [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) antes de executar uma operação que exija o modelo completo de objetos da apresentação.

{{% alert color="warning" title="Warning" %}}
Metadados públicos podem expor nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores personalizados. Criptografe propriedades sensíveis juntamente com a apresentação. Deixe‑as públicas apenas quando sistemas de indexação, classificação, pesquisa ou gerenciamento de documentos tiverem um requisito específico para acessá‑las sem senha.
{{% /alert %}}

## **Atualizar Propriedades de uma Apresentação Criptografada**

Para um arquivo PPTX criptografado, uma apresentação carregada no modo somente‑document‑properties destina‑se à leitura de metadados públicos. Aspose.Slides não pode salvar propriedades alteradas desse objeto somente‑metadados porque as propriedades públicas devem permanecer consistentes com os dados correspondentes dentro da apresentação criptografada. Atualizá‑las, portanto, requer a senha de abertura correta e um carregamento completo.

O exemplo a seguir abre a apresentação com [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), atualiza as propriedades públicas incorporadas e salva o resultado. Em seguida, usa [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) para verificar se a criptografia foi preservada e reabre os metadados públicos sem senha para validar os novos valores:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Se uma aplicação não estiver autorizada a descriptografar ou carregar o conteúdo da apresentação, ela deve tratar as propriedades públicas de um arquivo PPTX criptografado como somente‑leitura.

## **Acessar Propriedades Incorporadas**

Essas propriedades expostas pelo objeto [IDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties) incluem: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**.

```java
import com.aspose.slides.*;

// Instanciar a classe Presentation que representa a apresentação
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto IDocumentProperties associado à Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Exibir as propriedades incorporadas
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificar Propriedades Incorporadas**

Modificar as propriedades incorporadas de arquivos de apresentação é tão simples quanto acessá‑las. Você pode simplesmente atribuir um valor string a qualquer propriedade desejada e o valor da propriedade será alterado. No exemplo abaixo, demonstramos como modificar as propriedades de documento incorporadas da apresentação usando Aspose.Slides para Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto IDocumentProperties associado à Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Definir as propriedades incorporadas
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Salvar sua apresentação em um arquivo
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Este exemplo modifica as propriedades incorporadas da apresentação, que podem ser visualizadas como mostrado abaixo:

|**Propriedades de documento incorporadas após modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Adicionar Propriedades de Documento Personalizadas**

Aspose.Slides para Java também permite que os desenvolvedores adicionem valores personalizados para as propriedades de documento da apresentação. O exemplo abaixo adiciona três propriedades personalizadas, então procura o nome armazenado no índice 2 e remove essa propriedade, de modo que a apresentação salva mantém duas delas. As propriedades personalizadas são indexadas em ordem alfabética, não na ordem em que foram adicionadas.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtendo propriedades do documento
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Adicionando propriedades personalizadas
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Obtendo o nome da propriedade em um índice específico
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Removendo a propriedade selecionada
    dProps.removeCustomProperty(getPropertyName);
    
    // Salvando a apresentação
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Propriedades de Documento Personalizadas Adicionadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Acessar e Modificar Propriedades Personalizadas**

Aspose.Slides para Java também permite que os desenvolvedores acessem os valores das propriedades personalizadas. O exemplo abaixo mostra como acessar e modificar todas essas propriedades personalizadas para uma apresentação.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto DocumentProperties associado à Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Acessar e modificar propriedades personalizadas
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Exibir nomes e valores das propriedades personalizadas
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modificar valores das propriedades personalizadas
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Salvar sua apresentação em um arquivo
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Este exemplo modifica as propriedades personalizadas da [PPTX](https://docs.fileformat.com/presentation/pptx/)presentation. As figuras a seguir mostram as propriedades personalizadas da apresentação antes e depois da modificação:

|**Propriedades Personalizadas antes da Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriedades Personalizadas depois da Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriedades de Documento Avançadas**

{{% alert color="info" title="Note" %}}
Novos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), e [WriteBindedPresentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) foram adicionados ao [IPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo); a lógica do setter da propriedade [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pt/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) foi alterada.
{{% /alert %}} 

Os dois novos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) foram adicionados à interface [IPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IPresentationInfo). Eles fornecem acesso rápido às propriedades de documento e permitem alterar e atualizar propriedades sem carregar toda a apresentação.

O cenário típico de carregar as propriedades, alterar algum valor e atualizar o documento pode ser implementado da seguinte forma:

```java
import com.aspose.slides.*;

// ler as informações da apresentação
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Há outra maneira de usar as propriedades de uma apresentação específica como modelo para atualizar propriedades em outras apresentações:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Um novo modelo pode ser criado do zero e então usado para atualizar várias apresentações:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Definir Idioma de Revisão**

Aspose.Slides fornece a propriedade LanguageId (exposta pela classe PortionFormat) para permitir que você defina o idioma de revisão de um documento PowerPoint. O idioma de revisão é o idioma para o qual a ortografia e a gramática no PowerPoint são verificadas.

Este código Java mostra como definir o idioma de revisão para um PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // definir o ID de um idioma de revisão

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir Idioma Padrão**

Este código Java mostra como definir o idioma padrão para toda a apresentação PowerPoint:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Adiciona uma nova forma retangular com texto
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Verifica o idioma da primeira porção
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exemplo ao Vivo**

Experimente o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API do Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **FAQ**

**Como posso remover uma propriedade incorporada de uma apresentação?**

Propriedades incorporadas são uma parte integral da apresentação e não podem ser removidas completamente. No entanto, você pode alterar seus valores ou defini‑las como vazias, se a propriedade permitir.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, seu valor atual será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar a apresentação completa?**

Sim. Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e depois [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) para ler os metadados de documento armazenados sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/). Consulte [Build a Lightweight Presentation Inventory](/slides/pt/java/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.

**Posso ler propriedades públicas de uma apresentação criptografada sem sua senha de abertura?**

Sim. A criptografia das propriedades do documento deve ter sido desativada antes da apresentação ser criptografada, e a apresentação deve ser carregada no modo somente‑document‑properties.

**Posso atualizar um arquivo PPTX criptografado no modo somente‑document‑properties?**

Não. Os dados de propriedades públicas e criptografadas devem permanecer consistentes, portanto, atualizar um arquivo PPTX criptografado requer o carregamento completo da apresentação com a senha de abertura correta.