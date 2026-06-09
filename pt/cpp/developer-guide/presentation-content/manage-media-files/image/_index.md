---
title: Otimizar o Gerenciamento de Imagens em Apresentações Usando C++
linktitle: Gerenciar Imagens
type: docs
weight: 10
url: /pt/cpp/image/
keywords:
- adicionar imagem
- adicionar imagem
- adicionar bitmap
- substituir imagem
- substituir imagem
- da web
- fundo
- adicionar PNG
- adicionar JPG
- adicionar SVG
- adicionar EMF
- adicionar WMF
- adicionar TIFF
- PowerPoint
- OpenDocument
- apresentação
- EMF
- SVG
- C++
- Aspose.Slides
description: "Simplifique o gerenciamento de imagens no PowerPoint e OpenDocument com Aspose.Slides para C++, otimizando o desempenho e automatizando seu fluxo de trabalho."
---
## **Introdução**

Imagens tornam as apresentações mais envolventes e interessantes. No Microsoft PowerPoint, você pode inserir imagens de um arquivo, da internet ou de outros locais nos slides. De forma semelhante, o Aspose.Slides permite que você adicione imagens aos slides em suas apresentações por meio de diferentes procedimentos. 

{{% alert title="Tip" color="primary" %}} 

A Aspose fornece conversores gratuitos—[JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem que as pessoas criem apresentações rapidamente a partir de imagens. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Se você quiser adicionar uma imagem como objeto de moldura — especialmente se pretende usar opções de formatação padrão nela para alterar seu tamanho, adicionar efeitos etc. — veja [Moldura de Imagem](/slides/pt/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Você pode manipular operações de entrada/saída envolvendo imagens e apresentações PowerPoint para converter uma imagem de um formato para outro. Veja estas páginas: converter [imagem para JPG](https://products.aspose.com/slides/pt/cpp/conversion/image-to-jpg/); converter [JPG para imagem](https://products.aspose.com/slides/pt/cpp/conversion/jpg-to-image/); converter [JPG para PNG](https://products.aspose.com/slides/pt/cpp/conversion/jpg-to-png/), converter [PNG para JPG](https://products.aspose.com/slides/pt/cpp/conversion/png-to-jpg/); converter [PNG para SVG](https://products.aspose.com/slides/pt/cpp/conversion/png-to-svg/), converter [SVG para PNG](https://products.aspose.com/slides/pt/cpp/conversion/svg-to-png/). 

{{% /alert %}}

O Aspose.Slides suporta operações com imagens nesses formatos populares: JPEG, PNG, GIF e outros. 

## **Adicionar Imagens Armazenadas Localmente aos Slides**

Você pode adicionar uma ou várias imagens do seu computador a um slide em uma apresentação. Este código de exemplo em C++ mostra como adicionar uma imagem a um slide:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **Adicionar Imagens da Web aos Slides**

Se a imagem que você deseja adicionar a um slide não estiver disponível no seu computador, você pode adicioná‑la diretamente da web. 

Este código de exemplo mostra como adicionar uma imagem da web a um slide em C++:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Adicionar Imagens aos Mestres de Slides**

Um mestre de slides é o slide principal que armazena e controla informações (tema, layout etc.) sobre todos os slides abaixo dele. Assim, quando você adiciona uma imagem a um mestre de slides, essa imagem aparece em todos os slides sob esse mestre. 

Este código de exemplo em C++ mostra como adicionar uma imagem a um mestre de slides:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Adicionar Imagens como Fundo de Slides**

Você pode decidir usar uma imagem como fundo para um slide específico ou vários slides. Nesse caso, você deve ver *[Definindo Imagens como Fundos para Slides](https://docs.aspose.com/slides/pt/cpp/presentation-background/#setting-images-as-background-for-slides)*.

## **Adicionar SVG a Apresentações**
Você pode adicionar ou inserir qualquer imagem em uma apresentação usando o método [AddPictureFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) que pertence à interface [IShapeCollection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_shape_collection).

Para criar um objeto de imagem baseado em uma imagem SVG, você pode fazer da seguinte maneira:

1. Criar objeto SvgImage para inseri‑lo na ImageShapeCollection
2. Criar objeto PPImage a partir de ISvgImage
3. Criar objeto PictureFrame usando a interface IPPImage

Este código de exemplo mostra como implementar as etapas acima para adicionar uma imagem SVG em uma apresentação:
``` cpp 
// O caminho para o diretório de documentos
System::String dataDir = u"D:\\Documents\\";

// Nome do arquivo SVG de origem
System::String svgFileName = dataDir + u"sample.svg";

// Nome do arquivo de saída da apresentação
System::String outPptxPath = dataDir + u"presentation.pptx";

// Criar nova apresentação
auto p = System::MakeObject<Presentation>();

// Ler o conteúdo do arquivo SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Criar objeto SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Criar objeto PPImage
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// Cria um novo PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// Salvar apresentação no formato PPTX
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **Converter SVG para um Conjunto de Formas**
A conversão de SVG para um conjunto de formas do Aspose.Slides é semelhante à funcionalidade do PowerPoint usada para trabalhar com imagens SVG:

![PowerPoint Popup Menu](img_01_01.png)

A funcionalidade é fornecida por uma das sobrecargas do método [AddGroupShape](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) da interface [IShapeCollection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_shape_collection) que aceita um objeto [ISvgImage](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_svg_image) como primeiro argumento.

Este código de exemplo mostra como usar o método descrito para converter um arquivo SVG em um conjunto de formas:

``` cpp 
// O caminho para o diretório de documentos
System::String dataDir = u"D:\\Documents\\";

// Nome do arquivo SVG de origem
System::String svgFileName = dataDir + u"sample.svg";

// Nome do arquivo de saída da apresentação
System::String outPptxPath = dataDir + u"presentation.pptx";

// Criar nova apresentação
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// Ler o conteúdo do arquivo SVG
System::String svgContent = File::ReadAllText(svgFileName);

// Criar objeto SvgImage
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// Obter tamanho do slide
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// Converter a imagem SVG em um grupo de formas dimensionando-a ao tamanho do slide
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// Salvar a apresentação no formato PPTX
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **Adicionar Imagens como EMF aos Slides**
O Aspose.Slides for C++ permite gerar imagens EMF a partir de planilhas Excel e adicionar as imagens como EMF em slides com o Aspose.Cells. 

Este código de exemplo mostra como executar a tarefa descrita:

``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// Save the workbook to stream
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

## **Substituir Imagens na Coleção de Imagens**

O Aspose.Slides permite substituir imagens armazenadas na coleção de imagens de uma apresentação (incluindo as usadas por formas de slide). Esta seção mostra várias abordagens para atualizar imagens na coleção. A API fornece métodos simples para substituir uma imagem usando dados brutos em bytes, uma instância de [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/), ou outra imagem que já exista na coleção.

Siga as etapas abaixo:

1. Carregue o arquivo de apresentação que contém imagens usando a classe [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/).
2. Carregue uma nova imagem de um arquivo em um array de bytes.
3. Substitua a imagem alvo pela nova imagem usando o array de bytes.
4. Na segunda abordagem, carregue a imagem em um objeto [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) e substitua a imagem alvo por esse objeto.
5. Na terceira abordagem, substitua a imagem alvo por uma imagem que já exista na coleção de imagens da apresentação.
6. Grave a apresentação modificada como um arquivo PPTX.

```cpp
// Instanciar a classe Presentation que representa um arquivo de apresentação.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// A primeira maneira.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// A segunda maneira.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// A terceira maneira.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// Salvar a apresentação em um arquivo.
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Usando o conversor GRATUITO Aspose [Text to GIF](https://products.aspose.app/slides/pt/text-to-gif), você pode animar textos facilmente, criar GIFs a partir de textos, etc. 

{{% /alert %}}

## **FAQ**

**A resolução original da imagem permanece intacta após a inserção?**

Sim. Os pixels originais são preservados, mas a aparência final depende de como a [picture](/slides/pt/cpp/picture-frame/) é dimensionada no slide e de qualquer compressão aplicada ao salvar.

**Qual a melhor forma de substituir o mesmo logotipo em dezenas de slides de uma só vez?**

Coloque o logotipo no mestre de slides ou em um layout e substitua‑lo na coleção de imagens da apresentação — as atualizações se propagarão para todos os elementos que utilizam esse recurso.

**Um SVG inserido pode ser convertido em formas editáveis?**

Sim. Você pode converter um SVG em um grupo de formas, após o que as partes individuais tornam‑se editáveis com as propriedades padrão de forma.

**Como posso definir uma imagem como fundo para vários slides de uma só vez?**

[Atribua a imagem como fundo](/slides/pt/cpp/presentation-background/) no mestre de slides ou no layout relevante — todos os slides que utilizarem esse mestre/layout herdarão o fundo.

**Como impedir que a apresentação “infle” de tamanho por causa de muitas imagens?**

Reutilize um único recurso de imagem em vez de duplicatas, escolha resoluções adequadas, aplique compressão ao salvar e mantenha os gráficos repetidos no mestre quando apropriado.