---
title: Gerenciar Propriedades da Apresentação em JavaScript
linktitle: Propriedades da Apresentação
type: docs
weight: 70
url: /pt/nodejs-java/presentation-properties/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Domine as propriedades de apresentação no Aspose.Slides for Node.js via Java e simplifique a pesquisa, a identidade visual e o fluxo de trabalho nos seus arquivos PowerPoint e OpenDocument."
---
## **Introdução**

O Aspose.Slides for Node.js via Java suporta propriedades de documento **integradas** e **personalizadas**. Use essas propriedades para ler e atualizar os metadados da apresentação, como autor, título e valores definidos pelo usuário.

O Aspose.Slides permite trabalhar com as propriedades de documento da apresentação através da classe [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties). Uma instância dessa classe é retornada por [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Os exemplos a seguir mostram como ler, modificar e gerenciar essas propriedades.

{{% alert color="info" title="Note" %}}
O Aspose.Slides gerencia os metadados de aplicação e produtor ao salvar apresentações; esses campos identificam o software que criou a saída.
{{% /alert %}}

## **Gerenciar Propriedades da Apresentação**

As propriedades de documento armazenam informações descritivas junto ao conteúdo da apresentação. Elas se dividem em duas categorias:

- **Propriedades integradas** contêm metadados padrão, como título, autor e estatísticas do documento.
- **Propriedades personalizadas** armazenam pares nome/valor definidos pelo usuário.

O Aspose.Slides for Node.js via Java fornece acesso a ambas as categorias. No PowerPoint, selecione **Arquivo → Informações → Propriedades → Propriedades avançadas** para inspecionar os metadados do documento. A caixa de diálogo agrupa as informações em guias como **Resumo**, **Estatísticas**, **Conteúdo** e **Personalizado**. Use a guia **Personalizado** para gerenciar propriedades definidas pelo usuário.

## **Ler Propriedades Públicas de uma Apresentação Criptografada**

Uma senha de abertura normalmente protege tanto o conteúdo da apresentação quanto as propriedades do documento. Quando uma apresentação é criptografada após chamar [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) com `false`, suas propriedades de documento permanecem públicas. Uma aplicação pode então chamar [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) com `true` e ler os metadados públicos sem fornecer a senha de abertura.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) controla o que o Aspose.Slides carrega; não descriptografa nada. Se as propriedades foram incluídas na criptografia, carregá‑las sem a senha falha. Se a apresentação não estiver criptografada, a opção é ignorada e a apresentação completa é carregada.

O exemplo requer uma apresentação criptografada cujas propriedades de documento foram deixadas públicas. Ele verifica o modo de carregamento através de [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) e então lê as propriedades integradas através de [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

Nesse modo, o conteúdo dos slides não é carregado. Slides, mestres, layouts, formas, mídia e outros objetos da apresentação ficam indisponíveis. As aplicações devem sempre verificar [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) antes de executar uma operação que requeira o modelo de objeto completo da apresentação.

{{% alert color="warning" title="Warning" %}}
Metadados públicos podem revelar nomes de autores, títulos, assuntos, palavras‑chave, informações da empresa, comentários e valores personalizados. Criptografe propriedades sensíveis juntamente com a apresentação. Deixe‑as públicas somente quando sistemas de indexação, classificação, pesquisa ou gerenciamento de documentos tiverem um requisito específico para acessá‑las sem senha.
{{% /alert %}}

## **Atualizar Propriedades de uma Apresentação Criptografada**

Para um arquivo PPTX criptografado, uma apresentação carregada após chamar [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) com `true` destina‑se à leitura de metadados públicos. O Aspose.Slides não pode salvar propriedades alteradas desse objeto somente‑metadados porque as propriedades públicas devem permanecer consistentes com os dados correspondentes dentro da apresentação criptografada. Atualizá‑las, portanto, requer a senha de abertura correta e um carregamento completo.

O exemplo requer uma apresentação PPTX criptografada com propriedades de documento públicas e uma senha de abertura conhecida. Ele abre a apresentação completa com [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword), atualiza as propriedades integradas públicas e salva o resultado. Em seguida, usa [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) para verificar que a criptografia foi preservada e reabre os metadados públicos sem senha para confirmar os novos valores:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Se uma aplicação não estiver autorizada a descriptografar ou carregar o conteúdo da apresentação, ela deve tratar as propriedades públicas de um arquivo PPTX criptografado como somente‑leitura.

## **Acessar Propriedades Integradas**

A classe [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) expõe metadados integrados por meio de métodos getter, incluindo [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) e [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). Este exemplo abre uma apresentação existente e imprime seus metadados armazenados no console. Os valores dependem da apresentação de entrada; alguns campos podem estar vazios.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

### **Relatar Número de Revisão e Tempo de Edição**

Para relatar o número de revisão e o tempo total de edição de cada arquivo PPTX na pasta `presentations`, use [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties). Ele retorna as [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) do arquivo sem carregar os slides para edição. O exemplo converte a duração registrada de milissegundos para horas, minutos e segundos. Para durações de 24 horas ou mais, ele prefixa o tempo com o número de dias completos.

```javascript
const fs = require("fs");
const path = require("path");
const slides = require("aspose.slides.via.java");

const folder = "presentations";
const files = fs.readdirSync(folder, { withFileTypes: true });
const factory = slides.PresentationFactory.getInstance();

console.log("File | RevisionNumber | TotalEditingTime");
for (const file of files) {
    if (!file.isFile() || path.extname(file.name).toLowerCase() !== ".pptx") {
        continue;
    }
    const filePath = path.join(folder, file.name);
    const info = factory.getPresentationInfo(filePath);
    const properties = info.readDocumentProperties();
    const totalSeconds = Math.floor(properties.getTotalEditingTime() / 1000);
    const days = Math.floor(totalSeconds / 86400);
    const hours = Math.floor(totalSeconds / 3600) % 24;
    const minutes = Math.floor(totalSeconds / 60) % 60;
    const seconds = totalSeconds % 60;
    const time = [hours, minutes, seconds].map(value => String(value).padStart(2, "0")).join(":");
    const editingTime = days > 0 ? `${days}.${time}` : time;
    console.log(`${file.name} | ${properties.getRevisionNumber()} | ${editingTime}`);
}
```

Para uma apresentação com tempo de edição registrado de 1 dia, 2 horas e 5 minutos, o relatório mostra a seguinte saída.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getRevisionNumber) lê um valor que as aplicações podem alterar com [setRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setRevisionNumber). O número de revisão por si só não pode determinar quantas vezes a apresentação foi salva ou reconstruir seu histórico de versões.

[getTotalEditingTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTotalEditingTime) lê a duração de edição registrada no arquivo. Um valor `00:00:00` significa que a duração armazenada é zero, mesmo que alguém tenha editado a apresentação.

## **Modificar Propriedades Integradas**

Para atualizar metadados integrados, use os métodos setter no objeto retornado por [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Este exemplo abre uma apresentação existente, chama [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) e [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager), então salva a apresentação atualizada com [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). O PPTX salvo contém os novos metadados.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gerenciar a Base de Hiperlink**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) devolve a base a nível de documento para hiperlinks relativos. Use [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) para alterá‑la ou limpá‑la. Isso é útil ao mover uma apresentação e seus arquivos vinculados para outro local. É diferente do [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) de um hiperlink individual: mudar a base não reescreve os endereços armazenados nem altera destinos absolutos.

O exemplo requer uma apresentação contendo tanto um link relativo, como `target.html`, quanto um link absoluto, como `https://example.org/absolute.html`. Ele lê a base existente, atribui uma nova base, salva e reabre a apresentação para verificar o valor. Em seguida, limpa a base com uma string vazia e verifica o valor vazio em um arquivo salvo separado. Substitua a base de exemplo pelo local dos seus arquivos vinculados.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

As duas mensagens de verificação devem imprimir `true`. Limpar a base deixa os endereços individuais dos hiperlinks intactos.

Um link relativo para `target.pptx` abriu `old/target.pptx` quando a base apontava para a pasta `old`. Após mudar a base para a pasta `new`, salvar e reabrir a apresentação, o mesmo link abriu `new/target.pptx`. Um link absoluto continuou a abrir o mesmo arquivo. Teste seus links relativos no PowerPoint antes e depois de mover a apresentação ou alterar sua base.

## **Adicionar Propriedades Personalizadas à Apresentação**

Propriedades personalizadas armazenam metadados que não possuem um campo integrado correspondente. O método [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) permite atribuir um valor pelo nome da propriedade. Este exemplo cria uma apresentação, adiciona dois valores de texto e um valor inteiro de versão, e salva a apresentação com [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Atribuir um valor a um nome já existente substitui o valor dessa propriedade.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Acessar e Modificar Propriedades Personalizadas**

Este exemplo abre uma apresentação contendo propriedades personalizadas e usa [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) para iterar sobre elas. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) aceita um índice baseado em zero e devolve o nome usado por [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item). O exemplo imprime cada nome e valor originais, substitui cada valor por uma cadeia numerada independentemente do tipo original e salva as alterações. Se não houver propriedades personalizadas, o loop não faz alterações.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Exemplo ao Vivo**

Experimente o aplicativo online [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) para ver como trabalhar com propriedades de documento usando a API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Como posso remover uma propriedade integrada de uma apresentação?**

Propriedades integradas são parte integral da apresentação e não podem ser removidas completamente. No entanto, você pode alterar seus valores ou defini‑las como vazias, se a propriedade específica permitir.

**O que acontece se eu adicionar uma propriedade personalizada que já existe?**

Se você adicionar uma propriedade personalizada que já existe, seu valor atual será sobrescrito pelo novo. Não é necessário remover ou verificar a propriedade antes, pois o Aspose.Slides atualiza automaticamente o valor da propriedade.

**Posso acessar as propriedades da apresentação sem carregar a apresentação completa?**

Sim. Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) e depois [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) para ler os metadados armazenados sem criar uma instância de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). Consulte [Build a Lightweight Presentation Inventory](/slides/pt/nodejs-java/examine-presentation/) para um exemplo completo de relatório e limitações específicas de formato.

**Posso ler propriedades públicas de uma apresentação criptografada sem sua senha de abertura?**

Sim. A apresentação deve ter sido criptografada após chamar [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) com `false`, e deve ser carregada após chamar [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) com `true`.

**Posso atualizar um arquivo PPTX criptografado no modo somente‑propriedades‑do‑documento?**

Não. Dados de propriedades públicas e criptografadas devem permanecer consistentes, portanto, atualizar um arquivo PPTX criptografado requer o carregamento completo da apresentação com a senha de abertura correta.