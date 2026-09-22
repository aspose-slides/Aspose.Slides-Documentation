---
title: Determinar o Formato Original da Apresentação no Android
linktitle: Formato de Origem
type: docs
weight: 35
url: /pt/androidjava/detect-presentation-source-format/
keywords:
- formato de origem
- detectar formato da apresentação
- PowerPoint
- OpenDocument
- apresentação
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Leia o formato original de uma apresentação carregada no Android com Aspose.Slides para Android via Java, compare APIs de detecção e manipule arquivos, streams e formatos legados."
---
## **Visão geral**

Depois de carregar uma apresentação, chame o método [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getSourceFormat--) para determinar seu formato original. O método também está disponível através de [IPresentation.getSourceFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Use‑o quando o processamento subsequente depende do formato a partir do qual a instância atual foi carregada.

O formato de origem é distinto do [SaveFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/) selecionado para um arquivo de saída. Salvar em outro formato não altera o formato de origem da instância existente.

Os exemplos usam Java e caminhos de arquivo. No Android, substitua os caminhos de exemplo por caminhos em armazenamento acessível ao aplicativo, como o diretório interno de arquivos do seu app.

## **Ler o Formato de Origem de um Arquivo**

Este exemplo requer um arquivo `sample.pptx` existente. Ele carrega o arquivo e seleciona uma política de processamento da aplicação usando [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getSourceFormat--), em vez de usar o nome do arquivo. Altere o caminho de entrada para testar outros formatos. O exemplo imprime a política selecionada; substitua as mensagens pela lógica da sua aplicação.

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

## **Reconhecer os Valores Compatíveis**

A classe [SourceFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/sourceformat/) define constantes inteiras que distinguem os seguintes formatos de apresentação. As extensões abaixo são convencionais, não uma reconstrução do nome de arquivo original.

| Valor SourceFormat | Extensão | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Apresentação PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Apresentação Office Open XML |
| `Pptm` | `.pptm` | Apresentação Office Open XML habilitada para macro |
| `Pps` | `.pps` | Apresentação de slides PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Apresentação de slides Office Open XML |
| `Ppsm` | `.ppsm` | Apresentação de slides Office Open XML habilitada para macro |
| `Pot` | `.pot` | Modelo PowerPoint 97–2003 |
| `Potx` | `.potx` | Modelo Office Open XML |
| `Potm` | `.potm` | Modelo Office Open XML habilitado para macro |
| `Odp` | `.odp` | Apresentação OpenDocument |
| `Otp` | `.otp` | Modelo de apresentação OpenDocument |
| `Fodp` | `.fodp` | Apresentação ODF XML plano |
| `Xml` | `.xml` | Apresentação PowerPoint XML |

## **Ler o Formato de Origem de um Stream**

Este exemplo requer um arquivo `sample.pps` existente. Ler seus bytes em um stream de memória representa entrada recebida sem um nome de arquivo, como um valor de banco de dados ou um array de bytes enviado. O construtor [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) recebe apenas o stream.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

PPT, PPS e POT usam o mesmo formato binário subjacente. Ao carregar por caminho de arquivo, a extensão pode ajudar a distinguir um show de slides ou modelo. Sem um nome de arquivo, o conteúdo legado PPS e POT pode ser reportado como `SourceFormat.Ppt`; o exemplo PPS acima imprime o valor inteiro de `SourceFormat.Ppt`.

Se a sua aplicação precisar preservar essa distinção, mantenha o nome de arquivo original ou metadados de subtipo separadamente. Uma extensão é uma dica útil para esses subtipos legados, mas não deve ser a única base para identificar conteúdo de apresentação arbitrário.

## **Comparar a Detecção Antes e Depois do Carregamento**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) quando precisar inspecionar um arquivo antes de carregar seu modelo de objeto de apresentação completo. Use [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getSourceFormat--) quando a instância já existir.

Este exemplo requer `sample.pptx` e imprime os valores inteiros de `LoadFormat.Pptx` e `SourceFormat.Pptx`, respectivamente. Em produção, escolha a API apropriada ao seu estágio de processamento; uma apresentação já carregada não precisa de uma segunda inspeção somente para obter seu formato de origem.

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

Os resultados usam constantes de classes diferentes: [LoadFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/sourceformat/). Não compare seus valores numéricos nem presuma que todo formato tenha resultados de detecção idênticos. PowerPoint XML pode ser relatado como `LoadFormat.Unknown` antes do carregamento e como `SourceFormat.Xml` após o carregamento.

## **Manter Formatos de Origem e de Saída Separados**

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

Uma apresentação criada do zero com `new Presentation()` relata `SourceFormat.Pptx`. Ela não tem arquivo de entrada: esse é o valor padrão para uma instância recém‑criada, não evidência de que um arquivo PPTX foi carregado. Controle se sua aplicação criou ou carregou a instância separadamente caso essa distinção seja importante.

## **Mapear um Formato de Origem para uma Extensão**

O exemplo a seguir requer `sample.pptx`. Ele mapeia cada valor atualmente compatível de [SourceFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/sourceformat/) para uma extensão convencional, sem analisar o nome do arquivo de entrada. O fallback evita atribuir silenciosamente uma extensão a um valor não reconhecido.

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

Esse mapeamento não converte um arquivo nem recupera um subtipo legado PPS/POT perdido durante o carregamento do stream. Para salvar efetivamente, selecione explicitamente um [SaveFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/saveformat/) ou use a conversão mostrada em [Save Presentations in Their Original Format](/slides/pt/androidjava/save-presentation/#save-presentations-in-their-original-format).

## **Verificar Formatos Salvando e Reabrindo**

Este exemplo autocontido cria uma apresentação e grava três arquivos no diretório de trabalho, sobrescrevendo arquivos com o mesmo nome. Ele reabre cada saída tanto por caminho quanto por meio de um stream de memória. Para PPTX e ODP, ambas as rotas relatam o formato salvo. Para PPS, o carregamento por caminho relata `Pps`, enquanto o carregamento dos mesmos bytes sem nome de arquivo relata `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

| Formato salvo | SourceFormat a partir de um caminho de arquivo | SourceFormat a partir de um stream sem nome |
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

O conteúdo PPS/POT é identificado como `Ppt` para streams sem nome. A tabela descreve a identificação de formato, não a preservação de todos os recursos da apresentação durante a conversão.

## **FAQ**

**Salvar em ODP altera o formato de origem de uma apresentação carregada a partir de PPTX?**

Não. A instância existente ainda relata `Pptx`. Uma instância carregada a partir do arquivo ODP salvo relata `Odp`.

**Um stream pode sempre distinguir uma apresentação legada, um show de slides e um modelo?**

Não. PPT, PPS e POT compartilham o formato binário. Mantenha o nome de arquivo ou metadados de subtipo separadamente quando essa distinção for necessária.

**Qual API devo usar se a apresentação já estiver carregada?**

Leia [Presentation.getSourceFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#getSourceFormat--). Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) para inspeção antes do carregamento.