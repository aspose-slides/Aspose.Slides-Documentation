---
title: Gerenciar Propriedades de Apresentação no Android
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/androidjava/presentation-properties/
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
- Android
- Java
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides para Android via Java e otimize pesquisa, branding e fluxo de trabalho em seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

Aspose.Slides oferece dois tipos de propriedades de documento: **Built-in** e **Custom**. Ambos os tipos de propriedade podem ser acessados e gerenciados facilmente usando a API Aspose.Slides.

Aspose.Slides permite que você trabalhe com as propriedades de documento de apresentações através da interface [IDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idocumentproperties/) . Uma instância desta interface é retornada por [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Observação" %}}
Observe que os campos **Application** e **AppVersion** não podem ser modificados. Aspose.Slides reescreve‑os a cada salvamento, de modo que uma apresentação salva sempre informa o nome do produto Aspose.Slides e a versão da biblioteca que a gerou. Qualquer valor passado para `setNameOfApplication` é descartado quando a apresentação é gravada.
{{% /alert %}} 

## **Propriedades de Documento no PowerPoint**

O Microsoft PowerPoint 2007 permite gerenciar as propriedades de documento dos arquivos de apresentação. Tudo o que você precisa fazer é clicar no ícone do Office e, em seguida, no item de menu **Prepare | Properties | Advanced Properties** do Microsoft PowerPoint 2007, como mostrado abaixo:

|**Selecionar item de menu Propriedades Avançadas**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Depois de selecionar o item de menu **Advanced Properties**, aparecerá uma caixa de diálogo que permite gerenciar as propriedades de documento do arquivo PowerPoint, como mostrado na figura abaixo:

|**Caixa de Diálogo de Propriedades**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Na **Caixa de Diálogo de Propriedades** acima, você pode ver várias páginas de abas como **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Todas essas abas permitem configurar diferentes tipos de informações relacionadas aos arquivos PowerPoint. A aba **Custom** é usada para gerenciar as propriedades personalizadas dos arquivos PowerPoint.

### Trabalhando com Propriedades de Documento usando Aspose.Slides para Android via Java

Como descrito anteriormente, Aspose.Slides para Android via Java oferece dois tipos de propriedades de documento, que são propriedades **Built-in** e **Custom**. Assim, os desenvolvedores podem acessar ambos os tipos de propriedades usando a API Aspose.Slides para Android via Java. Aspose.Slides para Android via Java fornece a classe [IDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idocumentproperties) que representa as propriedades de documento associadas a um arquivo de apresentação por meio da propriedade **Presentation.DocumentProperties**.

Os desenvolvedores podem usar a propriedade **IDocumentProperties** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation) para acessar as propriedades de documento dos arquivos de apresentação conforme descrito abaixo:

## **Ler Propriedades Públicas de uma Apresentação Criptografada**

Uma senha de abertura normalmente protege tanto o conteúdo da apresentação quanto as propriedades do documento. Quando uma apresentação é criptografada passando `false` para [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), suas propriedades de documento permanecem públicas. Uma aplicação pode então passar `true` para [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) e ler os metadados públicos sem fornecer a senha de abertura.

A opção document-properties-only controla o que o Aspose.Slides carrega; ela não descriptografa nada. Se as propriedades estavam incluídas na criptografia, carregá‑las sem a senha falha. Se a apresentação não estiver criptografada, a opção é ignorada e a apresentação completa é carregada.

O exemplo a seguir verifica o modo de carregamento através de [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) e então lê as propriedades **Built-in** através de [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):
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

Nesse modo, o conteúdo dos slides não é carregado. Slides, mestres, layouts, formas, mídia e outros objetos da apresentação ficam indisponíveis. As aplicações devem sempre verificar [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) antes de executar uma operação que requer o modelo de objeto completo da apresentação.
{{% alert color="warning" title="Aviso" %}}
Metadados públicos podem expor nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores personalizados. Criptografe propriedades sensíveis juntamente com a apresentação. Deixe‑as públicas somente quando indexação, classificação, pesquisa ou sistemas de gerenciamento de documentos tiverem um requisito específico para acessá‑las sem senha.
{{% /alert %}}

## **Atualizar Propriedades de uma Apresentação Criptografada**

Para um arquivo PPTX criptografado, uma apresentação carregada no modo document-properties-only destina‑se à leitura de metadados públicos. O Aspose.Slides não pode salvar propriedades alteradas desse objeto que contém apenas metadados porque as propriedades públicas devem permanecer consistentes com os dados correspondentes dentro da apresentação criptografada. Atualizá‑las, portanto, requer a senha de abertura correta e um carregamento completo.

O exemplo a seguir abre a apresentação com [LoadOptions.setPassword](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), atualiza as propriedades **Built-in** públicas e salva o resultado. Em seguida, usa [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) para verificar que a criptografia foi preservada e reabre os metadados públicos sem senha para verificar os novos valores:
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

Se uma aplicação não tem permissão para descriptografar ou carregar o conteúdo da apresentação, ela deve tratar as propriedades públicas de um arquivo PPTX criptografado como somente leitura.

## **Acessar Propriedades Built-in**

Essas propriedades expostas pelo objeto [IDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idocumentproperties) incluem: **Creator** (Autor), **Description**, **Keywords**, **Created** (Data de Criação), **Modified** (Data de Modificação), **Printed** (Data da Última Impressão), **LastModifiedBy**, **Keywords**, **SharedDoc** (É compartilhado entre diferentes produtores?), **PresentationFormat**, **Subject** e **Title**
```java
import com.aspose.slides.*;

// Instanciar a classe Presentation que representa a apresentação
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto IDocumentProperties associado à Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Exibir as propriedades integradas
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

## **Modificar Propriedades Built-in**

Modificar as propriedades built-in de arquivos de apresentação é tão fácil quanto acessá‑las. Você pode simplesmente atribuir um valor string a qualquer propriedade desejada e o valor da propriedade será alterado. No exemplo abaixo, demonstramos como podemos modificar as propriedades de documento built-in do arquivo de apresentação usando Aspose.Slides para Android via Java.
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Criar uma referência ao objeto IDocumentProperties associado à Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Definir as propriedades integradas
    dp.setAuthor("Aspose.Slides for Android via Java");
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

Este exemplo modifica as propriedades built-in da apresentação, que podem ser visualizadas como mostrado abaixo:

|**Propriedades de documento Built-in após modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Adicionar Propriedades de Documento Personalizadas**

Aspose.Slides para Android via Java também permite que os desenvolvedores adicionem valores personalizados às propriedades de documento da apresentação. O exemplo abaixo adiciona três propriedades personalizadas, consulta o nome armazenado no índice 2 e remove essa propriedade, de forma que a apresentação salva mantêm duas delas. As propriedades personalizadas são indexadas em ordem alfabética, não na ordem em que foram adicionadas.
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Obtendo Propriedades do Documento
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

Aspose.Slides para Android via Java também permite que os desenvolvedores acessem os valores das propriedades personalizadas. Um exemplo é apresentado abaixo, mostrando como acessar e modificar todas essas propriedades personalizadas de uma apresentação.
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

Este exemplo modifica as propriedades personalizadas da apresentação [PPTX ](https://docs.fileformat.com/presentation/pptx/) . As figuras a seguir mostram as propriedades personalizadas da apresentação antes e depois da modificação:

|**Propriedades Personalizadas antes da Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Propriedades Personalizadas após Modificação**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Propriedades Avançadas de Documento**

{{% alert color="info" title="Observação" %}}
Novos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), e [WriteBindedPresentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) foram adicionados ao [IPresentationInfo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPresentationInfo); a lógica do setter da propriedade [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) foi alterada.
{{% /alert %}} 

Os dois novos métodos [ReadDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) foram adicionados à interface [IPresentationInfo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IPresentationInfo). Eles fornecem acesso rápido às propriedades de documento e permitem alterar e atualizar propriedades sem carregar uma apresentação inteira.

O cenário típico de carregar as propriedades, alterar algum valor e atualizar o documento pode ser implementado da seguinte maneira:
```java
import com.aspose.slides.*;

// ler as informações da apresentação
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obter as propriedades atuais
IDocumentProperties props = info.readDocumentProperties();

// definir os novos valores dos campos Autor e Título
props.setAuthor("New Author");
props.setTitle("New Title");

// atualizar a apresentação com novos valores
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Existe outra forma de usar as propriedades de uma apresentação específica como modelo para atualizar propriedades em outras apresentações:
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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Definir Idioma de Revisão**

Aspose.Slides fornece a propriedade LanguageId (exposta pela classe PortionFormat) para permitir que você defina o idioma de revisão de um documento PowerPoint. O idioma de revisão é o idioma para o qual a ortografia e a gramática no PowerPoint são verificadas.
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

    portionFormat.setLanguageId("zh-CN"); // definir o Id de um idioma de revisão

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

Experimente o aplicativo online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/pt/metadata) para ver como trabalhar com propriedades de documento via API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/pt/metadata)

## **FAQ**

**Como posso remover uma propriedade built-in de uma apresentação?**

As propriedades built-in são parte integrante da apresentação e não podem ser removidas totalmente. Contudo, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, seu valor existente será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade previamente, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregá‑la completamente?**

Sim. Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e então [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) para ler os metadados de documento armazenados sem criar uma instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/). Veja [Build a Lightweight Presentation Inventory](/slides/pt/androidjava/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.

**Posso ler propriedades públicas de uma apresentação criptografada sem sua senha de abertura?**

Sim. A criptografia das propriedades de documento deve ter sido desativada antes da apresentação ser criptografada, e a apresentação deve ser carregada no modo document‑properties‑only.

**Posso atualizar um arquivo PPTX criptografado no modo document‑properties‑only?**

Não. Os dados de propriedades públicas e criptografadas devem permanecer consistentes, portanto, atualizar um arquivo PPTX criptografado requer o carregamento completo da apresentação com a senha de abertura correta.