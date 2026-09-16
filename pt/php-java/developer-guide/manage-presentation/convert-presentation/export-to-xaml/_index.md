---
title: Exportar Apresentações para XAML em PHP
linktitle: Apresentação para XAML
type: docs
weight: 30
url: /pt/php-java/export-to-xaml/
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
- PHP
- Aspose.Slides
description: "Converta slides PowerPoint e OpenDocument para XAML usando Aspose.Slides para PHP via Java — solução rápida, sem necessidade do Office, que mantém seu layout intacto."
---
## **Visão Geral**

Este artigo explica como exportar apresentações do PowerPoint para XAML usando Aspose.Slides. Inclui uma breve introdução ao XAML, mostra como salvar uma apresentação em XAML com as configurações padrão e demonstra como personalizar a exportação através de [XamlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/), incluindo a exportação de slides ocultos. O artigo também responde a algumas perguntas comuns relacionadas a fontes de fallback, compatibilidade de pilhas XAML e comportamento de exportação de slides ocultos.

## **Sobre XAML**

XAML é uma linguagem de marcação baseada em XML usada para descrever interfaces de usuário em frameworks como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

Você pode trabalhar com arquivos XAML em um designer visual ou escrever e editar a marcação diretamente.

## **Exportar Apresentações para XAML com Opções Padrão**

O exemplo PHP a seguir mostra como exportar uma apresentação para XAML com as configurações padrão. Inicialize o PHP Java Bridge e carregue `aspose.slides.php` antes de executar os exemplos neste artigo. Coloque `pres.pptx` no diretório de trabalho do servidor Java Bridge ou forneça um caminho absoluto acessível a esse servidor.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

Por padrão, os slides exportados são salvos em uma subpasta `pres` do diretório de trabalho atual do servidor Java Bridge. A pasta é criada automaticamente, e quaisquer imagens necessárias são salvas lá também.

O nome da pasta de saída é derivado do nome do arquivo de origem sem sua extensão. Para `pres.pptx`, os arquivos de saída são nomeados `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e assim por diante. Mesmo que você passe um caminho absoluto para a apresentação de entrada, a pasta de saída é criada em relação ao diretório de trabalho atual do servidor Java Bridge, e não ao lado do arquivo de entrada.

## **Exportar Apresentações para XAML com Opções Personalizadas**

Use a interface [IXamlOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloptions/) para controlar como o Aspose.Slides exporta uma apresentação para XAML.

Para salvar a saída em um local personalizado, forneça um proxy Java que implemente [IXamlOutputSaver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloutputsaver/) e passe uma instância da sua implementação ao método [setOutputSaver](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/#setOutputSaver) de [XamlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/).

Para incluir slides ocultos na saída XAML, chame [setExportHiddenSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) com `true`, como mostrado no exemplo PHP a seguir:

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}
```

## **Capturar Todos os Artefatos XAML Gerados**

Uma exportação XAML pode produzir um documento XAML para cada slide exportado, além de imagens separadas e recursos de suporte. Atribua um [IXamlOutputSaver](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloutputsaver/) personalizado a [XamlOptions::setOutputSaver](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/#setOutputSaver) para receber esses artefatos em vez de usar o salvador padrão do sistema de arquivos. Inicie a exportação com a sobrecarga específica de XAML de [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save) que aceita opções XAML.

A função `java_closure` do PHP Java Bridge expõe um objeto PHP como a interface Java. Mantenha tanto o salvador PHP quanto seu proxy ativos até que a exportação termine. Os links da interface apontam para a API Java implementada pelo proxy.

### **Entender o Ciclo de Vida do Callback**

O exportador chama [IXamlOutputSaver::save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separadamente para cada artefato gerado:

- `path` identifica o artefato e pode incluir diretórios relativos. Preserve esta informação porque o XAML pode referenciar recursos usando caminhos relativos.
- `data` contém os bytes do artefato. Imagens e outros recursos binários não devem ser decodificados como texto.
- O salvador é responsável por reter ou persistir os dados antes de retornar. Os exemplos convertem cada array de bytes Java em uma string binária PHP de propriedade da aplicação.
- Considere a exportação como bem‑sucedida somente quando a operação de salvamento da apresentação retornar e todos os callbacks tiverem concluído com sucesso. Não ignore erros de armazenamento nem inicie gravações em segundo plano não observadas. Se a persistência ocorrer posteriormente, reporte o sucesso geral somente após essa etapa também ser bem‑sucedida.

[XamlOptions::setExportHiddenSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) também se aplica a um salvador personalizado. A configuração padrão, `false`, exclui documentos XAML de slides ocultos. Passar `true` inclui-os e quaisquer recursos necessários para sua exportação. A contagem de recursos depende da apresentação; não presuma um callback por slide ou uma ordem fixa de callbacks.

### **Exportar para a Memória e Inspecionar os Artefatos**

Este exemplo completo carrega `pres.pptx`, coleta cada artefato em um array associativo PHP de strings binárias e imprime seu nome, tipo e contagem de bytes. Ele preserva os nomes fornecidos exatamente. Nomes duplicados marcam a coleção como inválida em vez de sobrescrever silenciosamente um artefato. O exemplo verifica isso antes de usar os resultados.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(true);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$inspectXamlText = false;
foreach ($saver->artifacts as $name => $bytes) {
    $extension = strtolower(pathinfo($name, PATHINFO_EXTENSION));
    $isXaml = $extension === "xaml";
    $isImage = in_array($extension, ["png", "jpg", "jpeg", "gif", "bmp", "tif", "tiff", "svg"], true);
    $kind = $isXaml ? "slide XAML" : ($isImage ? "image" : "supporting resource");
    echo $name . ": " . strlen($bytes) . " bytes (" . $kind . ")" . PHP_EOL;

    // Somente XAML é tratado como texto UTF-8 para inspeção opcional.
    if ($isXaml && $inspectXamlText) {
        echo $bytes . PHP_EOL;
    }
}
```

Verificações de extensão são úteis para inspeção; retenha todos os artefatos, incluindo tipos de recurso desconhecidos. Deixe os bytes inalterados ao armazená‑los ou transmiti‑los. Strings PHP podem reter dados binários, inclusive bytes zero. Trate uma string como texto UTF‑8 somente ao inspecionar o XAML; não transcodifique bytes de imagem ou recurso.

### **Empacotar Artefatos Coletados em um Arquivo ZIP**

Este exemplo independente coleta a exportação, valida seus nomes e grava os bytes originais em um arquivo ZIP. Um diretório de trabalho criado exclusivamente separa trabalhos de exportação concorrentes. Este exemplo requer a extensão PHP Phar com suporte a ZIP. Entradas ZIP usam barras normais e preservam diretórios relativos. Nomes inseguros ou que colidem após normalização rejeitam todo o pacote antes de ser escrito.

```php
use aspose\slides\Presentation;
use aspose\slides\XamlOptions;

class MemoryXamlSaver {
    public $artifacts = [];
    public $valid = true;

    public function save($path, $data) {
        $name = (string) java_values($path);
        if (array_key_exists($name, $this->artifacts)) {
            $this->valid = false;
            echo "Export rejected: duplicate artifact name: " . $name . PHP_EOL;
            return;
        }
        $bytes = java_values($data);
        if (is_string($bytes)) {
            $binary = $bytes;
        } else {
            $binary = "";
            foreach ($bytes as $byte) {
                $binary .= chr($byte & 0xff);
            }
        }
        $this->artifacts[$name] = $binary;
    }
}

$saver = new MemoryXamlSaver();
$proxy = java_closure($saver, null, java("com.aspose.slides.IXamlOutputSaver"));
$presentation = new Presentation("pres.pptx");
try {
    $options = new XamlOptions();
    $options->setOutputSaver($proxy);
    $options->setExportHiddenSlides(false);
    $presentation->save($options);
} finally {
    $presentation->dispose();
}

if (!$saver->valid) {
    echo "Export rejected: the artifact collection is invalid." . PHP_EOL;
    return;
}

$entries = [];
$entryNames = [];
foreach ($saver->artifacts as $name => $bytes) {
    $entryName = str_replace("\\", "/", $name);
    $unsafeName = substr($entryName, 0, 1) === "/" || strpos($entryName, ":") !== false;
    foreach (explode("/", $entryName) as $segment) {
        $unsafeName = $unsafeName || trim($segment) === "" || $segment === "." || $segment === "..";
    }
    $key = strtolower($entryName);
    if ($unsafeName || isset($entryNames[$key])) {
        echo "Export rejected: unsafe or duplicate artifact name: " . $name . PHP_EOL;
        return;
    }
    $entryNames[$key] = true;
    $entries[$entryName] = $bytes;
}

$jobDirectory = "xaml-" . bin2hex(random_bytes(16));
if (!mkdir($jobDirectory, 0700)) {
    echo "Cannot create the export directory." . PHP_EOL;
    return;
}
$archivePath = $jobDirectory . "/export.zip";
try {
    $archive = new PharData($archivePath, 0, null, Phar::ZIP);
    foreach ($entries as $name => $bytes) {
        $archive->addFromString($name, $bytes);
    }
    unset($archive);
    echo "Saved " . count($entries) . " artifacts to " . $archivePath . PHP_EOL;
} catch (Throwable $exception) {
    unset($archive);
    echo "Archive persistence failed: " . $exception->getMessage() . PHP_EOL;
}
```

O exemplo usa [PharData](https://www.php.net/manual/en/class.phardata.php) para gravar um arquivo ZIP local no diretório de trabalho do processo PHP; o exportador em si não grava arquivos XAML ou de imagem soltos. Para armazenamento remoto, substitua a etapa de gravação do arquivo pelo upload das strings binárias coletadas. Use um identificador de trabalho de exportação mais a hierarquia completa do nome relativo do artefato como chave de blob, ou armazene o identificador do trabalho, o nome relativo e os dados binários em uma linha de banco de dados. Publique o trabalho somente após todos os uploads concluírem ou a transação do banco de dados for confirmada. Limpe a saída parcial se a persistência falhar.

Para apresentações grandes, um salvador personalizado pode persistir cada artefato diretamente no armazenamento da aplicação para evitar manter uma cópia adicional de toda a exportação na memória da aplicação. Mantenha cada callback síncrono do ponto de vista do exportador: retorne somente após o destino aceitar os bytes e permita que falhas alcancem o chamador.

### **Preservar Nomes de Recursos e Verificar Referências**

- Normalize separadores de caminho quando o destino exigir, mas preserve diretórios relativos. Não use apenas [basename](https://www.php.net/manual/en/function.basename.php) a menos que cada nome gerado seja conhecido como único e as referências de recurso permaneçam válidas.
- Aplique validação de nomes específica ao destino. Ao gravar arquivos soltos, rejeite caminhos raiz e segmentos de travessia, resolva o destino para um caminho absoluto e verifique se ele permanece dentro do diretório de exportação pretendido, incluindo o separador de diretório na verificação de contenção. Use um diretório controlado pela aplicação sem links simbólicos que possam redirecionar gravações.
- Use um salvador e um namespace de armazenamento separados para cada trabalho de exportação. Detecte colisões após a normalização de separadores e de acordo com as regras de sensibilidade a maiúsculas/minúsculas do destino.
- Antes de publicar, analise cada documento XAML como XML e inspecione suas referências de recursos baseadas em arquivo, como atributos `Source` ou `ImageSource` de imagens. Resolva cada URI relativo contra o diretório do artefato XAML contendo, normalize o nome de armazenamento resultante e confirme que a chave de mapa correspondente, a entrada ZIP ou o objeto armazenado exista. Trate URIs externos e expressões de marcação XAML separadamente de nomes de arquivos relativos.

Por exemplo, se `pres/Slide_1.xaml` referencia `images/image1.png`, o recurso armazenado deve estar disponível como `pres/images/image1.png`. Manter apenas `image1.png` quebraria essa relação. Para armazenamento de objetos, preserve a mesma estrutura sob o prefixo do trabalho e torne essas URLs de recurso acessíveis ao consumidor XAML. Reabra o ZIP concluído para verificar nomes de entradas e bytes de recursos, e carregue slides representativos no ambiente XAML de destino para confirmar que as imagens são resolvidas corretamente.

## **FAQ**

**Como posso garantir fontes previsíveis se a fonte original não estiver disponível na máquina?**

Chame [setDefaultRegularFont](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) em [XamlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/) — ele é usado como fonte de fallback durante a exportação quando a original está ausente. Isso não garante que o XAML gerado referencie a fonte de fallback ou que a fonte esteja disponível na máquina de destino. Certifique‑se de que as fontes referenciadas pelo XAML estejam disponíveis no ambiente onde ele será exibido.

**O XAML exportado destina‑se apenas ao WPF ou pode ser usado em outras pilhas XAML também?**

Aspose.Slides exporta XAML WPF através de sua API pública. A compatibilidade com outras pilhas XAML, como UWP e Xamarin.Forms, não é garantida. Teste a marcação gerada no seu ambiente de destino.

**Slides ocultos são suportados e como posso impedir que eles sejam exportados por padrão?**

Por padrão, slides ocultos não são incluídos. Você pode controlar esse comportamento via [setExportHiddenSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/#setExportHiddenSlides) em [XamlOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/xamloptions/) — mantenha‑a desativada se não precisar exportá‑los.