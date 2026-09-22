---
title: Determinar o Formato Original da Apresentação em Node.js
linktitle: Formato de Origem
type: docs
weight: 35
url: /pt/nodejs-java/detect-presentation-source-format/
keywords:
- formato de origem
- detectar formato de apresentação
- PowerPoint
- OpenDocument
- apresentação
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Leia o formato original de uma apresentação carregada em Node.js com Aspose.Slides para Node.js via Java, compare as APIs de detecção e manipule arquivos, streams e formatos legados."
---
## **Visão geral**

Após carregar uma apresentação, chame o método [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSourceFormat) para determinar seu formato original. Use‑o quando o processamento subsequente depender do formato a partir do qual a instância atual foi carregada.

O formato de origem é distinto do [SaveFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/) selecionado para um arquivo de saída. Salvar em outro formato não altera o formato de origem da instância existente.

## **Ler o Formato de Origem de um Arquivo**

Este exemplo requer um arquivo `sample.pptx` existente. Ele carrega o arquivo e seleciona uma política de processamento da aplicação usando [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSourceFormat), em vez do nome do arquivo. Altere o caminho de entrada para experimentar outros formatos. O exemplo imprime a política selecionada; substitua as mensagens pela lógica da sua aplicação.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Reconhecer os Valores Compatíveis**

A classe [SourceFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sourceformat/) define constantes inteiras que distinguem os seguintes formatos de apresentação. As extensões abaixo são extensões convencionais, não uma reconstrução do nome de arquivo original.

| Valor SourceFormat | Extensão | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Apresentação PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Apresentação Office Open XML |
| `Pptm` | `.pptm` | Apresentação Office Open XML com macros |
| `Pps` | `.pps` | Apresentação de slides PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Apresentação de slides Office Open XML |
| `Ppsm` | `.ppsm` | Apresentação de slides Office Open XML com macros |
| `Pot` | `.pot` | Modelo PowerPoint 97–2003 |
| `Potx` | `.potx` | Modelo Office Open XML |
| `Potm` | `.potm` | Modelo Office Open XML com macros |
| `Odp` | `.odp` | Apresentação OpenDocument |
| `Otp` | `.otp` | Modelo de apresentação OpenDocument |
| `Fodp` | `.fodp` | Apresentação ODF Flat XML |
| `Xml` | `.xml` | Apresentação PowerPoint XML |

## **Ler o Formato de Origem de um Stream**

Este exemplo requer um arquivo `sample.pps` existente. Ler seus bytes em um stream de memória modela a entrada recebida sem um nome de arquivo, como um valor de banco de dados ou um array de bytes enviado. O construtor [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) recebe apenas o stream.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS e POT usam o mesmo formato binário subjacente. Ao carregar pelo caminho do arquivo, a extensão pode ajudar a distinguir uma apresentação de slides ou um modelo. Sem um nome de arquivo, o conteúdo legado de PPS e POT pode ser relatado como `SourceFormat.Ppt`; o exemplo de PPS acima imprime o valor inteiro de `SourceFormat.Ppt`.

Se sua aplicação precisar preservar a distinção, mantenha o nome de arquivo original ou os metadados de subtipo separadamente. Uma extensão é uma dica útil para esses subtipos legados, mas não deve ser a única base para identificar conteúdo de apresentação arbitrário.

## **Comparar a Detecção Antes e Depois do Carregamento**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) e [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) quando precisar inspecionar um arquivo antes de carregar seu modelo de objeto de apresentação completo. Use [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSourceFormat) quando a instância já existe.

Este exemplo requer `sample.pptx` e imprime os valores inteiros de `LoadFormat.Pptx` e `SourceFormat.Pptx`, respectivamente. Em produção, escolha a API adequada ao seu estágio de processamento; uma apresentação já carregada não precisa de uma segunda inspeção apenas para obter seu formato de origem.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Os resultados utilizam constantes de classes diferentes: [LoadFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sourceformat/). Não compare seus valores numéricos nem presuma que todo formato tenha resultados de detecção idênticos. PowerPoint XML pode ser relatado como `LoadFormat.Unknown` antes do carregamento e `SourceFormat.Xml` após o carregamento.

## **Manter Formatos de Origem e de Saída Separados**

Este exemplo requer `sample.pptx` e grava `converted.odp`. Ele imprime o valor inteiro de `SourceFormat.Pptx` tanto antes quanto depois de salvar a instância original. Apenas a nova instância carregada a partir da saída ODP reporta `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Uma apresentação criada do zero com `new Presentation()` relata `SourceFormat.Pptx`. Ela não possui arquivo de entrada: este é o valor padrão para uma instância recém‑criada, não evidência de que um arquivo PPTX foi carregado. Acompanhe se sua aplicação criou ou carregou a instância separadamente se essa distinção for importante.

## **Mapear um Formato de Origem para uma Extensão**

O exemplo a seguir requer `sample.pptx`. Ele mapeia cada valor atualmente suportado de [SourceFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sourceformat/) para uma extensão convencional, sem analisar o nome de arquivo de entrada. O fallback evita atribuir silenciosamente uma extensão a um valor não reconhecido.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Este mapeamento não converte um arquivo nem recupera um subtipo legado PPS/POT perdido durante o carregamento do stream. Para salvar realmente, selecione explicitamente um [SaveFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveformat/), ou use a conversão mostrada em [Save Presentations in Their Original Format](/slides/pt/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Verificar Formatos Salvando e Reabrindo**

Este exemplo autônomo cria uma apresentação e grava três arquivos no diretório de trabalho, sobrescrevendo arquivos com os mesmos nomes. Ele reabre cada saída tanto por caminho quanto por meio de um stream de memória. Para PPTX e ODP, ambas as rotas reportam o formato salvo. Para PPS, o carregamento por caminho relata `Pps`, enquanto o carregamento dos mesmos bytes sem nome de arquivo relata `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

A tabela a seguir resume a identificação do formato de origem para apresentações com extensões correspondentes. Os nomes denotam constantes; os exemplos JavaScript imprimem seus valores inteiros:

| Formato salvo | SourceFormat a partir de um caminho de arquivo | SourceFormat a partir de um stream sem nome |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivamente | Mesmo que o caminho do arquivo |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivamente | Mesmo que o caminho do arquivo |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivamente | Mesmo que o caminho do arquivo |
| ODP, OTP | `Odp`, `Otp` respectivamente | Mesmo que o caminho do arquivo |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

O conteúdo PPS/POT é identificado como `Ppt` para streams sem nome. A tabela descreve a identificação de formatos, não a preservação de todos os recursos da apresentação durante a conversão.

## **Perguntas frequentes**

**Salvar em ODP altera o formato de origem de uma apresentação carregada a partir de PPTX?**

Não. A instância existente ainda relata `Pptx`. Uma instância carregada a partir do arquivo ODP salvo relata `Odp`.

**Um stream pode sempre distinguir uma apresentação legada, uma apresentação de slides e um modelo?**

Não. PPT, PPS e POT compartilham o formato binário. Mantenha o nome de arquivo ou metadados de subtipo separadamente quando essa distinção for necessária.

**Qual API devo usar se a apresentação já estiver carregada?**

Leia [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#getSourceFormat). Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) para inspeção antes do carregamento.