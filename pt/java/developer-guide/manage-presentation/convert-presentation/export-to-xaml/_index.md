---
title: Exportar apresentações para XAML em Java
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Converta slides PowerPoint e OpenDocument para XAML em Java usando Aspose.Slides - solução rápida, sem Office, que mantém seu layout intacto."
---
## **Visão geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através de [XamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade de pilhas XAML e comportamento de exportação de slides ocultos.

## **Sobre o XAML**

XAML é uma linguagem de marcação baseada em XML usada para descrever interfaces de usuário em estruturas como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

Você pode trabalhar com arquivos XAML em um designer visual ou escrever e editar a marcação diretamente.

## **Exportar apresentações para XAML com opções padrão**

O exemplo Java a seguir demonstra como exportar uma apresentação para XAML com as configurações padrão:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Por padrão, os slides exportados são salvos em uma subpasta `pres` do diretório de trabalho atual do processo, resolvida a partir de um caminho vazio com [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...). A pasta é criada automaticamente, e quaisquer imagens necessárias são salvas lá também.

O nome da pasta de saída é obtido a partir do nome do arquivo de origem sem sua extensão. Para `pres.pptx`, os arquivos de saída são nomeados `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e assim por diante. Mesmo que você passe um caminho absoluto para a apresentação de entrada, a pasta de saída é criada em relação ao diretório de trabalho atual, e não ao lado do arquivo de entrada.

## **Exportar apresentações para XAML com opções personalizadas**

Use a interface [IXamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloptions/) para controlar como Aspose.Slides exporta uma apresentação para XAML.

Para salvar a saída em um local personalizado, implemente [IXamlOutputSaver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloutputsaver/) e passe uma instância da sua implementação ao método [setOutputSaver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) de [XamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/).

Para incluir slides ocultos na saída XAML, chame [setExportHiddenSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) com `true`, como mostra o exemplo Java a seguir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Capturar todos os artefatos XAML gerados**

Uma exportação XAML pode produzir um documento XAML para cada slide exportado, além de imagens separadas e recursos de suporte. Atribua um [IXamlOutputSaver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloutputsaver/) personalizado a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) para receber esses artefatos em vez de usar o salvador padrão do sistema de arquivos. Inicie a exportação com a sobrecarga específica de XAML de [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) que aceita opções XAML.

### **Entender o ciclo de vida da callback**

O exportador chama [IXamlOutputSaver.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separadamente para cada artefato gerado:

- `path` identifica o artefato e pode incluir diretórios relativos. Preserve essas informações porque o XAML pode referenciar recursos usando caminhos relativos.
- `data` contém os bytes do artefato. Imagens e outros recursos binários não devem ser decodificados como texto.
- O salvador é responsável por reter ou persistir os dados antes de retornar. Os exemplos copiam cada array de bytes para memória pertencente à aplicação.
- Considere a exportação bem‑sucedida somente quando a operação de salvamento da apresentação retornar e todas as callbacks tiverem concluído com sucesso. Não ignore erros de armazenamento nem inicie gravações em segundo plano não observadas. Se a persistência ocorrer posteriormente, relate o sucesso geral somente após essa etapa também ter êxito.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) também se aplica a um salvador personalizado. A configuração padrão, `false`, exclui documentos XAML de slides ocultos. Passar `true` os inclui, bem como quaisquer recursos necessários para sua exportação. A quantidade de recursos depende da apresentação; não presuma uma callback por slide ou uma ordem fixa de callbacks.

### **Exportar para memória e inspecionar os artefatos**

Este exemplo completo carrega `pres.pptx`, coleta cada artefato em um [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) e imprime seu nome, tipo e contagem de bytes. Ele preserva os nomes fornecidos exatamente. Nomes duplicados tornam a coleção inválida em vez de sobrescrever silenciosamente um artefato. O exemplo verifica isso antes de usar os resultados.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // Decodifique apenas XAML, e somente quando a inspeção textual for necessária.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

Verificações de extensão são úteis para inspeção; retenha todos os artefatos, incluindo tipos de recurso desconhecidos. Deixe os bytes inalterados ao armazená‑los ou transmiti‑los. Use o construtor [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) com UTF‑8 somente para XAML que precise de processamento textual.

### **Empacotar artefatos coletados em um arquivo ZIP**

Este exemplo independente coleta a exportação, valida seus nomes e grava os bytes originais em um arquivo ZIP. Um nome de arquivo único separa trabalhos de exportação concorrentes. Entradas ZIP usam barras normais e preservam diretórios relativos. Nomes inseguros ou que colidem após a normalização são rejeitados antes da gravação do pacote.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // O diretório ZIP foi finalizado ao fechar antes de relatar o sucesso.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

O exemplo utiliza [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) para gravar um arquivo de arquivo local; o exportador em si não grava arquivos XAML ou imagens soltos. Para armazenamento remoto, substitua a fase de gravação do arquivo por uploads dos arrays de bytes coletados. Use um identificador de trabalho de exportação mais o nome de artefato relativo completo como chave de blob, ou armazene o identificador do trabalho, o nome relativo e os dados binários em uma linha de banco de dados. Publique o trabalho somente após todos os uploads concluírem ou a transação do banco de dados for confirmada. Limpe a saída parcial se a persistência falhar.

Para apresentações grandes, um salvador personalizado pode persistir cada artefato diretamente no armazenamento da aplicação para evitar manter uma cópia adicional de toda a exportação na memória da aplicação. Mantenha cada callback síncrona do ponto de vista do exportador: retorne somente após o destino aceitar os bytes e permita que falhas cheguem ao chamador.

### **Preservar nomes de recursos e verificar referências**

- Normalize os separadores de caminho quando o destino exigir, mas preserve diretórios relativos. Não use apenas [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) a menos que cada nome gerado seja conhecido como único e as referências de recurso permaneçam válidas.
- Aplique validação de nomes específica ao destino. Ao gravar arquivos soltos, rejeite caminhos absolutos e segmentos de travessia, resolva o destino com [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--), e verifique se ele permanece dentro do diretório de exportação pretendido, incluindo o separador de diretório na verificação de contenção. Use um diretório controlado pela aplicação sem links simbólicos que possam redirecionar gravações.
- Use um salvador e um namespace de armazenamento separados para cada trabalho de exportação. Detecte colisões após a normalização de separadores e de acordo com as regras de sensibilidade a maiúsculas/minúsculas do destino.
- Antes de publicar, analise cada documento XAML como XML e inspecione suas referências a recursos baseados em arquivo, como atributos `Source` ou `ImageSource` de imagens. Resolva cada URI relativa em relação ao diretório do artefato XAML contendo, normalize o nome de armazenamento resultante e confirme que a chave correspondente no mapa, a entrada ZIP ou o objeto armazenado exista. Trate URIs externos e expressões de marcação XAML separadamente de nomes de arquivos relativos.

Por exemplo, se `pres/Slide_1.xaml` referenciar `images/image1.png`, o recurso armazenado deve estar disponível como `pres/images/image1.png`. Manter apenas `image1.png` quebraria essa relação. Para armazenamento de objetos, preserve o mesmo layout sob o prefixo do trabalho e torne essas URLs de recurso acessíveis ao consumidor XAML. Reabra o ZIP concluído para verificar nomes de entrada e bytes de recurso, e carregue slides representativos no ambiente XAML de destino para confirmar que as imagens são resolvidas corretamente.

## **Perguntas frequentes**

**Como garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Chame [setDefaultRegularFont](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) em [XamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/) — ele é usado como fonte de fallback durante a exportação quando a original está ausente. Isso não garante que o XAML gerado referencie a fonte de fallback ou que a fonte esteja disponível na máquina de destino. Certifique‑se de que as fontes referenciadas pelo XAML estejam disponíveis no ambiente onde ele será exibido.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

Aspose.Slides exporta XAML WPF através de sua API pública. A compatibilidade com outras pilhas XAML, como UWP e Xamarin.Forms, não é garantida. Teste a marcação gerada no seu ambiente de destino.

**Slides ocultos são suportados e como evitar que sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [setExportHiddenSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) em [XamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/xamloptions/) — mantenha‑a desabilitada se não precisar exportá‑los.