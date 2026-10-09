---
title: Exportar apresentações para XAML em JavaScript
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/nodejs-java/export-to-xaml/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar apresentação
- converter PowerPoint
- converter OpenDocument
- converter apresentação
- PowerPoint para XAML
- OpenDocument para XAML
- apresentação para XAML
- PPT para XAML
- PPTX para XAML
- ODP para XAML
- salvar PPT como XAML
- salvar PPTX como XAML
- salvar ODP como XAML
- exportar PPT para XAML
- exportar PPTX para XAML
- exportar ODP para XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Converter slides PowerPoint e OpenDocument para XAML em JavaScript usando Aspose.Slides—solução rápida, sem necessidade do Office, que preserva seu layout."
---
## **Visão geral**

Este artigo explica como exportar apresentações PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através de [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade de pilhas XAML e comportamento de exportação de slides ocultos.

## **Sobre XAML**

XAML é uma linguagem de marcação baseada em XML usada para descrever interfaces de usuário em frameworks como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

Você pode trabalhar com arquivos XAML em um designer visual ou escrever e editar a marcação diretamente.

## **Exportar apresentações para XAML com opções padrão**

O exemplo JavaScript a seguir mostra como exportar uma apresentação para XAML com as configurações padrão:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Por padrão, os slides exportados são salvos em uma subpasta `input` do diretório de trabalho atual do processo. A pasta é criada automaticamente, e quaisquer imagens necessárias também são salvas lá.

O nome da pasta de saída é obtido a partir do nome do arquivo de origem, sem sua extensão. No Aspose.Slides para Node.js via Java 26.8, exportar `input.pptx` gera um caminho aninhado como `input/input/Slide_1.xaml`. Preserve os caminhos completos gerados ao lidar com a saída. A saída padrão é relativa ao diretório de trabalho atual, e não necessariamente ao lado do arquivo de entrada.

## **Exportar apresentações para XAML com opções personalizadas**

Use a interface [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) para controlar como o Aspose.Slides exporta uma apresentação para XAML.

Para salvar a saída em um local personalizado, implemente [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) e passe uma instância da sua implementação para o método [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) de [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

Para incluir slides ocultos na saída XAML, chame [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) com `true`, como mostrado no exemplo JavaScript a seguir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Capturar todos os artefatos XAML gerados**

Uma exportação XAML pode gerar um documento XAML para cada slide exportado, além de imagens separadas e recursos de suporte. Atribua um [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) personalizado a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) para receber esses artefatos em vez de usar o salvador padrão do sistema de arquivos. Inicie a exportação com a sobrecarga específica de XAML de [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) que aceita opções XAML.

No Node.js, implemente a interface Java com `java.newProxy` do pacote `java` usado pelo Aspose.Slides. Mantenha o proxy acessível até que a exportação seja concluída.

### **Entender o ciclo de vida do callback**

O exportador chama [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separadamente para cada artefato gerado:

- `path` identifica o artefato e pode incluir diretórios relativos. Mantenha essa informação porque o XAML pode referenciar recursos usando caminhos relativos.
- `data` contém os bytes do artefato. Imagens e outros recursos binários não devem ser decodificados como texto.
- O salvador é responsável por reter ou persistir os dados antes de retornar. Os exemplos copiam cada array de bytes Java para um buffer Node.js controlado pela aplicação.
- Considere a exportação bem‑sucedida somente quando a operação de salvamento da apresentação retornar e todos os callbacks tiverem sido concluídos com sucesso. Não ignore erros de armazenamento ou inicie gravações em segundo plano não observadas. Se a persistência ocorrer posteriormente, relate o sucesso geral somente após essa etapa também ser bem‑sucedida.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) também se aplica a um salvador personalizado. A configuração padrão, `false`, exclui documentos XAML de slides ocultos. Passar `true` inclui‑os e quaisquer recursos necessários para sua exportação. A contagem de recursos depende da apresentação; não presuma um callback por slide ou uma ordem fixa de callbacks.

### **Exportar para memória e inspecionar os artefatos**

Este exemplo completo carrega `input.pptx`, coleta cada artefato em um mapa JavaScript de nomes para buffers e imprime seu nome, tipo e contagem de bytes. Ele preserva os nomes fornecidos exatamente. Nomes duplicados marcam a coleção como inválida em vez de sobrescrever silenciosamente um artefato. O exemplo verifica isso antes de usar os resultados.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Decodificar apenas XAML, e somente quando a inspeção textual for necessária.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Verificações de extensão são úteis para inspeção; retenha todos os artefatos, incluindo tipos de recurso desconhecidos. Deixe os bytes inalterados ao armazená‑los ou transmiti‑los. Use decodificação UTF‑8 somente para XAML que necessite de processamento textual.

### **Empacotar artefatos coletados em um arquivo ZIP**

Este exemplo independente coleta a exportação, valida seus nomes e grava os bytes originais em um arquivo ZIP usando a ponte Java. O ZIP é montado na memória antes de ser salvo em disco. Um nome de arquivo exclusivo separa trabalhos de exportação concorrentes. As entradas do ZIP usam barras normais e preservam diretórios relativos. Nomes inseguros ou nomes que colidem após a normalização rejeitam todo o pacote antes de ser gravado.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // O fechamento finaliza o diretório ZIP antes que o arquivo seja persistido.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

O exemplo usa [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) para gravar um arquivo local; o exportador em si não grava arquivos XAML ou imagens soltos. Para armazenamento remoto, substitua a etapa de gravação do arquivo por uploads dos arrays de bytes coletados. Use um identificador de trabalho de exportação mais o nome relativo completo do artefato como chave de blob, ou armazene o identificador do trabalho, o nome relativo e os dados binários em uma linha de banco de dados. Publique o trabalho somente depois que todos os uploads forem concluídos ou a transação do banco de dados for confirmada. Limpe a saída parcial se a persistência falhar.

Para apresentações grandes, um salvador personalizado pode persistir cada artefato diretamente no armazenamento da aplicação para evitar manter uma cópia adicional de toda a exportação na memória da aplicação. Mantenha cada callback síncrono do ponto de vista do exportador: retorne somente após o destino ter aceitado os bytes e permita que falhas cheguem ao chamador.

### **Preservar nomes de recursos e verificar referências**

- Normalizar os separadores de caminho quando o destino o exigir, mas preservar diretórios relativos. Não use apenas o nome base a menos que cada nome gerado seja conhecido como único e as referências de recurso permaneçam válidas.
- Aplicar validação de nomes específica ao destino. Ao gravar arquivos soltos, rejeitar caminhos absolutos e segmentos de travessia, resolver o destino para um caminho absoluto e verificar se ele permanece dentro do diretório de exportação pretendido, incluindo o separador de diretório na verificação de contenção. Use um diretório controlado pela aplicação sem links simbólicos que possam redirecionar gravações.
- Use um salvador e um namespace de armazenamento separados para cada trabalho de exportação. Detecte colisões após a normalização dos separadores e de acordo com as regras de sensibilidade a maiúsculas/minúsculas do destino.
- Antes de publicar, analise cada documento XAML como XML e inspeccione suas referências de recursos baseados em arquivos, como atributos de imagem `Source` ou `ImageSource`. Resolva cada URI relativo contra o diretório do artefato XAML que o contém, normalize o nome de armazenamento resultante e confirme que a chave de mapa correspondente, a entrada ZIP ou o objeto armazenado existe. Trate URIs externos e expressões de marcação XAML separadamente de nomes de arquivos relativos.

Por exemplo, se `input/Slide_1.xaml` referenciar `images/image1.png`, o recurso armazenado deve estar disponível como `input/images/image1.png`. Manter apenas `image1.png` quebraria essa relação. Para armazenamento de objetos, preserve a mesma estrutura sob o prefixo do trabalho e torne essas URLs de recurso acessíveis ao consumidor XAML. Reabra o ZIP concluído para verificar os nomes das entradas e os bytes dos recursos, e carregue slides representativos no ambiente XAML de destino para confirmar que as imagens são resolvidas corretamente.

## **Perguntas frequentes**

**Como garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Chame [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) em [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — ele é usado como fonte de fallback durante a exportação quando a fonte original está ausente. Isso não garante que o XAML gerado faça referência à fonte de fallback ou que a fonte esteja disponível na máquina de destino. Certifique‑se de que as fontes referenciadas pelo XAML estejam disponíveis no ambiente onde ele será exibido.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

O Aspose.Slides exporta XAML WPF através de sua API pública. A compatibilidade com outras pilhas XAML, como UWP e Xamarin.Forms, não é garantida. Teste a marcação gerada no seu ambiente de destino.

**Slides ocultos são suportados e como posso impedir que sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) em [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — mantenha‑lo desativado se não precisar exportá‑los.