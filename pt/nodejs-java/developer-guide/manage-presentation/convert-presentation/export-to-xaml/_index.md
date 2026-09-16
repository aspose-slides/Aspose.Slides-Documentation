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
description: "Converta slides PowerPoint e OpenDocument para XAML em JavaScript usando Aspose.Slides—solução rápida, sem necessidade do Office, que mantém seu layout intacto."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através de [XamlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade de pilhas XAML e comportamento de exportação de slides ocultos.

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

O nome da pasta de saída é obtido a partir do nome do arquivo-fonte sem sua extensão. No Aspose.Slides for Node.js via Java 26.8, exportar `input.pptx` produz um caminho aninhado como `input/input/Slide_1.xaml`. Preserve os caminhos gerados completos ao manipular a saída. A saída padrão é relativa ao diretório de trabalho atual, e não necessariamente ao lado do arquivo de entrada.

## **Exportar apresentações para XAML com opções personalizadas**

Use a interface [IXamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloptions/) para controlar como o Aspose.Slides exporta uma apresentação para XAML.

Para salvar a saída em um local personalizado, implemente [IXamlOutputSaver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloutputsaver/) e passe uma instância da sua implementação ao método [setOutputSaver](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) de [XamlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/).

Para incluir slides ocultos na saída XAML, chame [setExportHiddenSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) com `true`, como mostrado no exemplo JavaScript a seguir:

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

Uma exportação XAML pode gerar um documento XAML para cada slide exportado, além de imagens separadas e recursos de suporte. Atribua um [IXamlOutputSaver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloutputsaver/) personalizado a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) para receber esses artefatos em vez de usar o salvador padrão do sistema de arquivos. Inicie a exportação com a sobrecarga específica de XAML de [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) que aceita opções XAML.

No Node.js, implemente a interface Java com `java.newProxy` do pacote `java` usado pelo Aspose.Slides. Mantenha o proxy acessível até que a exportação seja concluída.

### **Entender o ciclo de vida do callback**

O exportador chama [IXamlOutputSaver.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separadamente para cada artefato gerado:

- `path` identifica o artefato e pode incluir diretórios relativos. Preserve essa informação porque o XAML pode referenciar recursos usando caminhos relativos.
- `data` contém os bytes do artefato. Imagens e outros recursos binários não devem ser decodificados como texto.
- O salvador é responsável por reter ou persistir os dados antes de retornar. Os exemplos copiam cada array de bytes Java para um buffer Node.js controlado pela aplicação.
- Considere a exportação bem‑sucedida somente quando a operação de salvamento da apresentação retornar e todos os callbacks tiverem sido concluídos com sucesso. Não sufoque erros de armazenamento nem inicie gravações em segundo plano não observadas. Caso a persistência ocorra posteriormente, reporte o sucesso geral apenas depois que essa etapa também for bem‑sucedida.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) também se aplica a um salvador personalizado. A configuração padrão, `false`, exclui documentos XAML de slides ocultos. Passar `true` inclui-os e quaisquer recursos necessários para sua exportação. A contagem de recursos depende da apresentação; não presuma um callback por slide ou uma ordem fixa de callbacks.

### **Exportar para memória e inspecionar os artefatos**

Este exemplo completo carrega `input.pptx`, coleta cada artefato em um mapa JavaScript de nomes para buffers e imprime seu nome, tipo e contagem de bytes. Ele preserva exatamente os nomes fornecidos. Nomes duplicados marcam a coleção como inválida ao invés de sobrescrever silenciosamente um artefato. O exemplo verifica isso antes de usar os resultados.

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

        // Decodificar apenas XAML e somente quando a inspeção textual for necessária.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Verificações de extensão são úteis para inspeção; retenha todos os artefatos, incluindo tipos de recurso desconhecidos. Deixe os bytes inalterados ao armazenar ou transmitir. Use decodificação UTF‑8 somente para XAML que necessite de processamento textual.

### **Empacotar artefatos coletados em um arquivo ZIP**

Este exemplo independente coleta a exportação, valida seus nomes e grava os bytes originais em um arquivo ZIP usando a ponte Java. O ZIP é montado em memória antes de ser salvo em disco. Um nome de arquivo único separa trabalhos de exportação concorrentes. As entradas ZIP usam barras normais e preservam diretórios relativos. Nomes inseguros ou que colidam após a normalização rejeitam todo o pacote antes de ser escrito.

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
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Fechar finaliza o diretório ZIP antes de o arquivo ser persistido.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

O exemplo usa [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) para gravar um único arquivo local; o exportador em si não grava arquivos XAML ou imagens soltos. Para armazenamento remoto, substitua a fase de gravação do arquivo por uploads dos arrays de bytes coletados. Use um identificador de job de exportação mais o nome relativo completo do artefato como chave de blob, ou armazene o identificador do job, o nome relativo e os dados binários em uma linha de banco de dados. Publique o job apenas após todos os uploads concluírem ou a transação do banco de dados ser confirmada. Limpe a saída parcial se a persistência falhar.

Para apresentações grandes, um salvador personalizado pode persistir cada artefato diretamente no armazenamento da aplicação para evitar manter uma cópia adicional de toda a exportação na memória da aplicação. Mantenha cada callback síncrono do ponto de vista do exportador: retorne somente após o destino aceitar os bytes e permita que falhas cheguem ao chamador.

### **Preservar nomes de recursos e verificar referências**

- Normalize separadores de caminho quando o destino exigir, mas preserve diretórios relativos. Não use apenas o nome base a menos que cada nome gerado seja conhecido por ser único e as referências de recursos permaneçam válidas.
- Aplique validação de nomes específica ao destino. Ao gravar arquivos soltos, rejeite caminhos absolutos e segmentos de travessia, resolva o destino para um caminho absoluto e verifique se ele permanece dentro do diretório de exportação pretendido, incluindo o separador de diretório na verificação de contenção. Use um diretório controlado pela aplicação sem links simbólicos que possam redirecionar gravações.
- Use um salvador e um namespace de armazenamento separados para cada job de exportação. Detecte colisões após a normalização de separadores e de acordo com as regras de sensibilidade a maiúsculas/minúsculas do destino.
- Antes de publicar, analise cada documento XAML como XML e inspecione suas referências de recursos baseadas em arquivos, como atributos `Source` ou `ImageSource` de imagens. Resolva cada URI relativa contra o diretório do artefato XAML que a contém, normalize o nome de armazenamento resultante e confirme que a chave correspondente no mapa, a entrada ZIP ou o objeto armazenado existe. Trate URIs externos e expressões de marcação XAML separadamente de nomes de arquivo relativos.

Por exemplo, se `input/Slide_1.xaml` referencia `images/image1.png`, o recurso armazenado deve estar disponível como `input/images/image1.png`. Manter apenas `image1.png` quebraria essa relação. Para armazenamento de objetos, preserve a mesma estrutura sob o prefixo do job e torne essas URLs de recurso acessíveis ao consumidor XAML. Reabra o ZIP concluído para verificar nomes de entradas e bytes de recursos, e carregue slides representativos no ambiente XAML de destino para confirmar que as imagens são resolvidas corretamente.

## **Perguntas frequentes**

**Como posso garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Chame [setDefaultRegularFont](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) em [XamlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/) — ele é usado como fonte de fallback durante a exportação quando a original está ausente. Isso não garante que o XAML gerado referencie a fonte de fallback ou que a fonte esteja disponível na máquina de destino. Certifique‑se de que as fontes referenciadas pelo XAML estejam disponíveis no ambiente onde ele será exibido.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

O Aspose.Slides exporta XAML WPF através de sua API pública. A compatibilidade com outras pilhas XAML, como UWP e Xamarin.Forms, não é garantida. Teste a marcação gerada no seu ambiente de destino.

**Slides ocultos são suportados e como posso impedir que sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [setExportHiddenSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) em [XamlOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/xamloptions/) — mantenha‑a desativada se não precisar exportá‑los.