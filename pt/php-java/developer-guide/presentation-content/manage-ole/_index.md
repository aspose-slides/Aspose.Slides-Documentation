---
title: Gerenciar OLE em Apresentações Usando PHP
linktitle: Gerenciar OLE
type: docs
weight: 40
url: /pt/php-java/manage-ole/
keywords:
- objeto OLE
- Vinculação e Incorporação de Objetos
- adicionar OLE
- incorporar OLE
- adicionar objeto
- incorporar objeto
- adicionar arquivo
- incorporar arquivo
- objeto vinculado
- arquivo vinculado
- alterar OLE
- ícone OLE
- título OLE
- extrair OLE
- extrair objeto
- extrair arquivo
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Otimize a gestão de objetos OLE em arquivos PowerPoint e OpenDocument com Aspose.Slides para PHP via Java. Incorpore, atualize e exporte conteúdo OLE sem esforço."
---
## **Introdução**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) é uma tecnologia da Microsoft que permite que dados e objetos criados em um aplicativo sejam colocados em outro aplicativo por meio de vínculo ou incorporação. 

{{% /alert %}} 

Considere um gráfico criado no MS Excel. O gráfico é então colocado dentro de um slide do PowerPoint. Esse gráfico do Excel é considerado um objeto OLE. 

- Um objeto OLE pode aparecer como um ícone. Nesse caso, ao clicar duas vezes no ícone, o gráfico é aberto em seu aplicativo associado (Excel), ou é solicitado que você selecione um aplicativo para abrir ou editar o objeto.
- Um objeto OLE pode exibir seu conteúdo real, como o conteúdo de um gráfico. Nesse caso, o gráfico é ativado no PowerPoint, a interface do gráfico é carregada e você pode modificar os dados do gráfico dentro do PowerPoint.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) permite inserir OLE Objects em slides como quadros de objeto OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Adicionar Quadros de Objeto OLE a Slides**

Assumindo que você já criou um gráfico no Microsoft Excel e deseja incorporá‑lo em um slide como um quadro de objeto OLE usando Aspose.Slides for PHP via Java, você pode fazer isso desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Obtenha a referência de um slide através de seu índice.
3. Leia o arquivo Excel como um array de bytes.
4. Adicione o [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) ao slide contendo o array de bytes e outras informações sobre o objeto OLE.
5. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos um gráfico de um arquivo Excel a um slide como um quadro de objeto OLE usando Aspose.Slides for PHP via Java. **Nota** que o construtor [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) recebe uma extensão de objeto incorporável como segundo parâmetro. Essa extensão permite que o PowerPoint interprete corretamente o tipo de arquivo e escolha a aplicação correta para abrir este objeto OLE.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Preparar dados para o objeto OLE.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Adicionar Quadros de Objeto OLE Vinculados**

Aspose.Slides for PHP via Java permite adicionar um [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) sem incorporar dados, mas apenas com um link para o arquivo.

Este código PHP mostra como adicionar um [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) com um arquivo Excel vinculado a um slide:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Adicionar um quadro de objeto OLE com um arquivo Excel vinculado.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Acessar Quadros de Objeto OLE**

Se um objeto OLE já está incorporado em um slide, você pode encontrá‑lo ou acessá‑lo facilmente desta forma:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Obtenha a referência do slide usando seu índice.
3. Acese a forma [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). No nosso exemplo, usamos o PPTX criado anteriormente que possui apenas uma forma no primeiro slide.
4. Depois que o quadro do objeto OLE for acessado, você pode realizar qualquer operação nele.

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) e seus dados de arquivo são acessados.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Obter os dados do arquivo incorporado.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Obter a extensão do arquivo incorporado.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Acessar Propriedades do Quadro de Objeto OLE Vinculado**

Aspose.Slides permite acessar as propriedades do quadro de objeto OLE vinculado.

Este código PHP mostra como verificar se um objeto OLE está vinculado e, em seguida, obter o caminho para o arquivo vinculado:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Verificar se o objeto OLE está vinculado.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Imprimir o caminho completo do arquivo vinculado.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Imprimir o caminho relativo do arquivo vinculado, se presente.
        // Somente apresentações PPT podem conter o caminho relativo.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Alterar Dados do Objeto OLE**

{{% alert color="info" title="Note" %}}

Nesta seção, o exemplo de código abaixo usa [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/).

{{% /alert %}}

Se um objeto OLE já está incorporado em um slide, você pode acessar esse objeto e modificar seus dados facilmente desta forma:

1. Carregue uma apresentação com o objeto OLE incorporado criando uma instância da classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Obtenha a referência do slide através de seu índice. 
3. Acese a forma [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). No nosso exemplo, usamos o PPTX criado anteriormente que tem uma forma no primeiro slide.
4. Depois que o quadro do objeto OLE for acessado, você pode realizar qualquer operação nele.
5. Crie um objeto `Workbook` e acesse os dados OLE.
6. Acese a `Worksheet` desejada e altere os dados.
7. Salve o `Workbook` atualizado em um fluxo.
8. Altere os dados do objeto OLE a partir do fluxo.

No exemplo abaixo, um quadro de objeto OLE (um objeto de gráfico Excel incorporado em um slide) é acessado, e seus dados de arquivo são modificados para atualizar os dados do gráfico.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Ler os dados do objeto OLE como um objeto Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Modificar os dados da planilha.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Alterar os dados do objeto do quadro OLE.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Incorporar Outros Tipos de Arquivo em Slides**

Além de gráficos do Excel, Aspose.Slides for PHP via Java permite incorporar outros tipos de arquivos em slides. Por exemplo, você pode inserir arquivos HTML, PDF e ZIP como objetos. Quando o usuário clica duas vezes no objeto inserido, ele é aberto automaticamente no programa relevante, ou o usuário é solicitado a selecionar um programa apropriado para abri‑lo.

Este código PHP mostra como incorporar HTML e ZIP em um slide:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Definir Tipos de Arquivo para Objetos Incorporados**

Ao trabalhar com apresentações, pode ser necessário substituir objetos OLE antigos por novos ou substituir um objeto OLE não suportado por um suportado. Aspose.Slides for PHP via Java permite definir o tipo de arquivo para um objeto incorporado, permitindo atualizar os dados do quadro OLE ou sua extensão.

Este código PHP mostra como definir o tipo de arquivo de um objeto OLE incorporado para `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Alterar o tipo de arquivo para ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Definir Imagens de Ícone e Títulos para Objetos Incorporados**

Após incorporar um objeto OLE, uma pré‑visualização composta por uma imagem de ícone é adicionada automaticamente. Essa pré‑visualização é o que os usuários veem antes de acessar ou abrir o objeto OLE. Se você quiser usar uma imagem e um texto específicos como elementos na pré‑visualização, pode definir a imagem do ícone e o título usando Aspose.Slides for PHP via Java.

Este código PHP mostra como definir a imagem do ícone e o título para um objeto incorporado:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Adicionar uma imagem aos recursos da apresentação.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Impedir que um Quadro de Objeto OLE Seja Redimensionado e Reposicionado**

Depois de adicionar um objeto OLE vinculado a um slide de apresentação, ao abrir a apresentação no PowerPoint, pode aparecer uma mensagem solicitando a atualização dos vínculos. Clicar no botão "Update Links" pode alterar o tamanho e a posição do quadro do objeto OLE porque o PowerPoint atualiza os dados do objeto OLE vinculado e atualiza a pré‑visualização. Para impedir que o PowerPoint solicite a atualização dos dados do objeto, chame o método [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) da classe [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) com `false`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Extrair Arquivos Incorporados**

Aspose.Slides for PHP via Java permite extrair os arquivos incorporados em slides como objetos OLE desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) que contém os objetos OLE que você pretende extrair.
2. Percorra todas as formas na apresentação e acesse as formas [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/).
3. Acese os dados dos arquivos incorporados a partir dos quadros de objeto OLE e grave‑os no disco.

Este código PHP mostra como extrair arquivos incorporados em um slide como objetos OLE:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**O conteúdo OLE será renderizado ao exportar slides para PDF/imagens?**

O que está visível no slide é renderizado — o ícone/imagem de substituição (pré‑visualização). O conteúdo OLE "ao vivo" não é executado durante a renderização. Se necessário, defina sua própria imagem de pré‑visualização para garantir a aparência esperada no PDF exportado.

Para também preservar o arquivo incorporado como um anexo PDF, chame [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) com `true`. Esta opção está desativada por padrão. Para um exemplo e instruções de verificação do anexo, veja [Preservar arquivos OLE incorporados como anexos PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Como posso bloquear um objeto OLE em um slide para que os usuários não possam movê‑lo/editar‑lo no PowerPoint?**

Bloqueie a forma: Aspose.Slides fornece bloqueios a nível de forma. Isso não é criptografia, mas impede efetivamente edições e movimentações acidentais.

**Os caminhos relativos para objetos OLE vinculados serão preservados no formato PPTX?**

No PPTX, a informação de "caminho relativo" não está disponível — apenas o caminho completo. Caminhos relativos são encontrados no formato PPT mais antigo. Para portabilidade, prefira caminhos absolutos confiáveis/URIs acessíveis ou a incorporação.