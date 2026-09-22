---
title: Determinar o Formato Original da Apresentação em Java
linktitle: Formato de Origem
type: docs
weight: 35
url: /pt/java/detect-presentation-source-format/
keywords:
- formato de origem
- detectar formato da apresentação
- PowerPoint
- OpenDocument
- apresentação
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Leia o formato original de uma apresentação carregada em Java com Aspose.Slides for Java, compare as APIs de detecção e manipule arquivos, streams e formatos legados."
---
## **Visão geral**

Após carregar uma apresentação, chame o método [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSourceFormat--) para determinar seu formato original. O método também está disponível através de [IPresentation.getSourceFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentation/#getSourceFormat--). Use‑o quando o processamento subsequente depender do formato a partir do qual a instância atual foi carregada.

O formato de origem é distinto do [SaveFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveformat/) selecionado para um arquivo de saída. Salvar em outro formato não altera o formato de origem da instância existente.

## **Ler o Formato de Origem de um Arquivo**

Este exemplo requer um arquivo `sample.pptx` existente. Ele carrega o arquivo e seleciona uma política de processamento da aplicação usando [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSourceFormat--), em vez do nome do arquivo. Altere o caminho de entrada para experimentar outros formatos. O exemplo imprime a política selecionada; substitua as mensagens pela lógica da sua aplicação.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Reconhecer os Valores Suportados**

A classe [SourceFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sourceformat/) define constantes inteiras que distinguem os seguintes formatos de apresentação. As extensões abaixo são extensões convencionais, não uma reconstrução do nome de arquivo original.

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
| `Fodp` | `.fodp` | Apresentação ODF XML plano |
| `Xml` | `.xml` | Apresentação PowerPoint XML |

## **Ler o Formato de Origem de um Stream**

Este exemplo requer um arquivo `sample.pps` existente. Ler seus bytes em um fluxo de memória modela a entrada recebida sem um nome de arquivo, como um valor de banco de dados ou um array de bytes carregado. O construtor [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) recebe apenas o fluxo.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS e POT usam o mesmo formato binário subjacente. Ao carregar pelo caminho de arquivo, a extensão pode ajudar a distinguir uma apresentação de slides ou modelo. Sem um nome de arquivo, o conteúdo legado de PPS e POT pode ser relatado como `SourceFormat.Ppt`; o exemplo de PPS acima imprime o valor inteiro de `SourceFormat.Ppt`.

Se sua aplicação precisar preservar a distinção, mantenha o nome de arquivo original ou os metadados de subtipo separadamente. Uma extensão é uma dica útil para esses subtipos legados, mas não deve ser a única base para identificar conteúdo de apresentação arbitrário.

## **Comparar a Detecção Antes e Depois do Carregamento**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) quando precisar inspecionar um arquivo antes de carregar seu modelo de objeto de apresentação completo. Use [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSourceFormat--) quando a instância já existir.

Este exemplo requer `sample.pptx` e imprime os valores inteiros de `LoadFormat.Pptx` e `SourceFormat.Pptx`, respectivamente. Em produção, escolha a API apropriada para sua fase de processamento; uma apresentação já carregada não precisa de uma segunda inspeção apenas para obter seu formato de origem.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Os resultados utilizam constantes de classes diferentes: [LoadFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sourceformat/). Não compare seus valores numéricos nem presuma que cada formato tenha resultados de detecção idênticos. O PowerPoint XML pode ser relatado como `LoadFormat.Unknown` antes do carregamento e `SourceFormat.Xml` após o carregamento.

## **Manter os Formatos de Origem e de Saída Separados**

Este exemplo requer `sample.pptx` e grava `converted.odp`. Ele imprime o valor inteiro de `SourceFormat.Pptx` tanto antes quanto depois de salvar a instância original. Apenas a nova instância carregada a partir da saída ODP relata `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Uma apresentação criada do zero com `new Presentation()` relata `SourceFormat.Pptx`. Ela não tem arquivo de entrada: esse é o valor padrão para uma instância recém‑criada, não evidência de que um arquivo PPTX foi carregado. Controle se sua aplicação criou ou carregou a instância separadamente se essa distinção for importante.

## **Mapear um Formato de Origem para uma Extensão**

O exemplo a seguir requer `sample.pptx`. Ele mapeia cada valor atualmente suportado de [SourceFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/sourceformat/) para uma extensão convencional, sem analisar o nome de arquivo de entrada. O fallback evita atribuir silenciosamente uma extensão a um valor não reconhecido.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Esse mapeamento não converte um arquivo nem recupera um subtipo legado de PPS/POT perdido durante o carregamento de stream. Para salvar efetivamente, selecione um [SaveFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveformat/) explicitamente, ou use a conversão mostrada em [Save Presentations in Their Original Format](/slides/pt/java/save-presentation/#save-presentations-in-their-original-format).

## **Verificar Formatos Salvando e Reabrindo**

Este exemplo autônomo cria uma apresentação e grava três arquivos no diretório de trabalho, sobrescrevendo arquivos com os mesmos nomes. Ele reabre cada saída tanto por caminho quanto através de um fluxo de memória. Para PPTX e ODP, ambas as rotas relatam o formato salvo. Para PPS, o carregamento por caminho relata `Pps`, enquanto o carregamento dos mesmos bytes sem nome de arquivo relata `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

A tabela a seguir resume a identificação do formato de origem para apresentações com extensões correspondentes. Os nomes denotam constantes; os exemplos Java imprimem seus valores inteiros:

| Formato salvo | SourceFormat a partir de caminho de arquivo | SourceFormat a partir de stream sem nome |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivamente | Igual ao caminho de arquivo |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivamente | Igual ao caminho de arquivo |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivamente | Igual ao caminho de arquivo |
| ODP, OTP | `Odp`, `Otp` respectivamente | Igual ao caminho de arquivo |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

## **Perguntas Frequentes**

**Salvar em ODP altera o formato de origem de uma apresentação carregada a partir de PPTX?**

Não. A instância existente ainda relata `Pptx`. Uma instância carregada a partir do arquivo ODP salvo relata `Odp`.

**Um stream pode sempre distinguir uma apresentação legada, apresentação de slides e modelo?**

Não. PPT, PPS e POT compartilham o formato binário. Mantenha o nome de arquivo ou os metadados de subtipo separadamente quando essa distinção for necessária.

**Qual API devo usar se a apresentação já estiver carregada?**

Leia [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSourceFormat--). Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) para inspeção antes do carregamento.