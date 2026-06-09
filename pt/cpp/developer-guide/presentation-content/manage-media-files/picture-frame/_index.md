---
title: Gerenciar Quadros de Imagem em Apresentações Usando C++
linktitle: Quadro de Imagem
type: docs
weight: 10
url: /pt/cpp/picture-frame/
keywords:
- quadro de imagem
- adicionar quadro de imagem
- criar quadro de imagem
- adicionar imagem
- criar imagem
- extrair imagem
- imagem raster
- imagem vetorial
- recortar imagem
- área recortada
- propriedade StretchOff
- formatação de quadro de imagem
- propriedades de quadro de imagem
- escala relativa
- efeito de imagem
- proporção
- transparência da imagem
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Adicione quadros de imagem a apresentações PowerPoint e OpenDocument com Aspose.Slides para C++. Simplifique seu fluxo de trabalho e melhore o design dos slides."
---
## **Introdução**

Um quadro de imagem é uma forma que contém uma imagem—é como uma foto emoldurada. 

Você pode adicionar uma imagem a um slide através de um quadro de imagem. Dessa forma, você formata a imagem formatando o quadro de imagem.

{{% alert title="Dica" color="primary" %}} 

A Aspose oferece conversores gratuitos—[JPEG para PowerPoint](https://products.aspose.app/slides/pt/import/jpg-to-ppt) e [PNG para PowerPoint](https://products.aspose.app/slides/pt/import/png-to-ppt)—que permitem criar apresentações rapidamente a partir de imagens. 

{{% /alert %}} 

## **Criar um Quadro de Imagem**

1. Crie uma instância da [classe Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).  
2. Obtenha a referência de um slide pelo seu índice.  
3. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_p_p_image) adicionando uma imagem à [IImagesCollection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_image_collection) associada ao objeto de apresentação que será usado para preencher a forma.  
4. Defina a largura e a altura da imagem.  
5. Crie um [PictureFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.picture_frame) com base na largura e altura da imagem usando o método `AddPictureFrame` exposto pelo objeto de forma associado ao slide referenciado.  
6. Adicione o quadro de imagem (contendo a foto) ao slide.  
7. Grave a apresentação modificada como um arquivo PPTX.  

Este código C++ demonstra como criar um quadro de imagem:

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carrega a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessa o primeiro slide
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Carrega a imagem que será adicionada à coleção de imagens da apresentação
// Obtém a imagem
auto image = Images::FromFile(filePath);

// Adiciona uma imagem à coleção de imagens da apresentação
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Adiciona um quadro de imagem ao slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Define a escala relativa de largura e altura
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// Aplica alguma formatação ao quadro de imagem
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

// Grava o arquivo PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

Os quadros de imagem permitem criar rapidamente slides de apresentação baseados em imagens. Quando você combina quadros de imagem com as opções de salvamento do Aspose.Slides, pode manipular operações de entrada/saída para converter imagens de um formato para outro. Você pode consultar estas páginas: converter [imagem para JPG](https://products.aspose.com/slides/pt/cpp/conversion/image-to-jpg/); converter [JPG para imagem](https://products.aspose.com/slides/pt/cpp/conversion/jpg-to-image/); converter [JPG para PNG](https://products.aspose.com/slides/pt/cpp/conversion/jpg-to-png/), converter [PNG para JPG](https://products.aspose.com/slides/pt/cpp/conversion/png-to-jpg/); converter [PNG para SVG](https://products.aspose.com/slides/pt/cpp/conversion/png-to-svg/), converter [SVG para PNG](https://products.aspose.com/slides/pt/cpp/conversion/svg-to-png/). 

{{% /alert %}}

## **Criar um Quadro de Imagem com Escala Relativa**

Alterando a escala relativa de uma imagem, você pode criar um quadro de imagem mais elaborado. 

1. Crie uma instância da [classe Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).  
2. Obtenha a referência de um slide pelo seu índice.  
3. Adicione uma imagem à coleção de imagens da apresentação.  
4. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_p_p_image) adicionando a imagem à [IImagesCollection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_image_collection) associada ao objeto de apresentação que será usado para preencher a forma.  
5. Defina a largura e a altura relativas da imagem no quadro de imagem.  
6. Grave a apresentação modificada como um arquivo PPTX.  

Este código C++ demonstra como criar um quadro de imagem com escala relativa:

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carrega a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessa o primeiro slide
SharedPtr<ISlide> slide = pres->get_Slide(0);

// Carrega a imagem a ser adicionada à coleção de imagens da apresentação
// Obtém a imagem
auto image = Images::FromFile(filePath);

// Adiciona uma imagem à coleção de imagens da apresentação
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Adiciona um quadro de imagem ao slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Define a escala relativa de largura e altura
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Grava o arquivo PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Extrair Imagens Raster de Quadros de Imagem**

Você pode extrair imagens raster de objetos [PictureFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.picture_frame) e salvá‑las em PNG, JPG e outros formatos. O exemplo de código abaixo demonstra como extrair uma imagem do documento “sample.pptx” e salvá‑la em formato PNG.

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **Extrair Imagens SVG de Quadros de Imagem**

Quando uma apresentação contém gráficos SVG inseridos em formas [PictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pictureframe/), o Aspose.Slides para C++ permite recuperar as imagens vetoriais originais com total fidelidade. Ao percorrer a coleção de formas do slide, você pode identificar cada [PictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pictureframe/), verificar se o [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) subjacente contém conteúdo SVG e, então, salvar essa imagem em disco ou em um fluxo no seu formato SVG nativo.

O exemplo de código a seguir demonstra como extrair uma imagem SVG de um quadro de imagem:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **Obter Transparência de uma Imagem**

O Aspose.Slides permite obter o efeito de transparência aplicado a uma imagem. Este código C++ demonstra a operação:

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="primary" %}} 
Todos os efeitos aplicados a imagens podem ser encontrados em [Aspose::Slides::Effects](https://reference.aspose.com/slides/pt/cpp/aspose.slides.effects/). 
{{% /alert %}}

## **Formatação de Quadros de Imagem**

O Aspose.Slides oferece muitas opções de formatação que podem ser aplicadas a um quadro de imagem. Usando essas opções, você pode modificar um quadro de imagem para que atenda a requisitos específicos.

1. Crie uma instância da [classe Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).  
2. Obtenha a referência de um slide pelo seu índice.  
3. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_p_p_image) adicionando uma imagem à [IImagesCollection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_image_collection) associada ao objeto de apresentação que será usado para preencher a forma.  
4. Defina a largura e a altura da imagem.  
5. Crie um `PictureFrame` com base na largura e altura da imagem usando o método [AddPictureFrame](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) exposto pelo objeto [IShapes](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_shape_collection) associado ao slide referenciado.  
6. Adicione o quadro de imagem (contendo a foto) ao slide.  
7. Defina a cor da linha do quadro de imagem.  
8. Defina a espessura da linha do quadro de imagem.  
9. Gire o quadro de imagem atribuindo-lhe um valor positivo ou negativo.  
   * Um valor positivo gira a imagem no sentido horário.  
   * Um valor negativo gira a imagem no sentido anti‑horário.  
10. Adicione o quadro de imagem (contendo a foto) ao slide.  
11. Grave a apresentação modificada como um arquivo PPTX.  

Este código C++ demonstra o processo de formatação de quadro de imagem:

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// Carrega a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Acessa o primeiro slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Carrega a imagem a ser adicionada à coleção de imagens da apresentação
// Obtém a imagem
auto image = Images::FromFile(filePath);

// Adiciona uma imagem à coleção de imagens da apresentação
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// Adiciona um quadro de imagem ao slide
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// Define a escala relativa de largura e altura
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// Grava o arquivo PPTX no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Dica" color="primary" %}}

A Aspose desenvolveu recentemente um [Criador de Colagens gratuito](https://products.aspose.app/slides/pt/collage). Se precisar [mesclar imagens JPG/JPEG](https://products.aspose.app/slides/pt/collage/jpg) ou PNG, ou [criar grades a partir de fotos](https://products.aspose.app/slides/pt/collage/photo-grid), pode usar este serviço. 

{{% /alert %}}

## **Adicionar uma Imagem como Link**

Para evitar tamanhos grandes de apresentação, você pode adicionar imagens (ou vídeos) por meio de links em vez de incorporar os arquivos diretamente nas apresentações. Este código C++ mostra como inserir uma imagem e um vídeo em um placeholder:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Recortar Imagens**

Este código C++ demonstra como recortar uma imagem existente em um slide: 

```CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// Cria novo objeto de imagem
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// Adiciona um PictureFrame a um Slide
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// Recorta a imagem (valores de porcentagem)
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// Salva o resultado
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Excluir Áreas Recortadas de um Quadro**

Se desejar excluir as áreas recortadas de uma imagem contida em um quadro, pode usar o método [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Esse método devolve a imagem recortada ou a imagem original caso o recorte seja desnecessário.

Este código C++ demonstra a operação: 

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTA" color="warning" %}} 

O método [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) adiciona a imagem recortada à coleção de imagens da apresentação. Se a imagem for usada apenas no [PictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pictureframe/) processado, essa configuração pode reduzir o tamanho da apresentação. Caso contrário, o número de imagens na apresentação resultante aumentará.

Esse método converte arquivos WMF/EMF para imagens PNG raster no processo de recorte. 

{{% /alert %}}

## **Compactar Imagens**

Você pode compactar uma imagem em uma apresentação usando o método [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/compressimage/). Esse método compacta uma imagem reduzindo seu tamanho com base no tamanho da forma e na resolução especificada, com a opção de excluir áreas recortadas.

Ele ajusta o tamanho e a resolução da imagem de forma semelhante ao recurso **Formato da Imagem → Compactar Imagens → Resolução** do PowerPoint.

Os exemplos C++ a seguir demonstram como compactar uma imagem em uma apresentação especificando uma resolução alvo e, opcionalmente, removendo áreas recortadas:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Compacta a imagem com resolução alvo de 150 DPI (resolução da Web) e remove áreas recortadas.
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// Verifica o resultado da compactação.
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ou usando diretamente um valor DPI personalizado:

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Compacta a imagem para 150 DPI (resolução da web), removendo áreas recortadas.
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTA" color="warning" %}}

O método converte a imagem para uma resolução inferior com base no tamanho da forma e no DPI fornecido. Regiões recortadas também podem ser excluídas para otimizar o tamanho do arquivo.  
Se a imagem for um metafile (WMF/EMF) ou SVG, a compactação não será aplicada. Além disso, a qualidade JPEG é preservada ou levemente reduzida conforme a resolução, de modo semelhante ao que o PowerPoint faz com JPEGs de alta resolução. 

{{% /alert %}}

## **Bloquear Proporção da Imagem**

Se desejar que uma forma que contém uma imagem mantenha sua proporção mesmo após alterar as dimensões da imagem, use o método [set_AspectRatioLocked()](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) para definir a configuração *Bloquear Proporção*. 

Este código C++ mostra como bloquear a proporção de uma forma:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// define a forma para preservar a proporção ao redimensionar
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTA" color="warning" %}} 

A configuração *Bloquear Proporção* preserva apenas a proporção da forma, não a da imagem que ela contém. 

{{% /alert %}}

## **Usar a Propriedade StretchOff**

Usando as propriedades [StretchOffsetLeft](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471), [StretchOffsetTop](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a), [StretchOffsetRight](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) e [StretchOffsetBottom](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) da interface [IPictureFillFormat](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_picture_fill_format) e da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.picture_fill_format), você pode especificar um retângulo de preenchimento. 

Quando o alongamento de uma imagem é especificado, um retângulo de origem é dimensionado para caber no retângulo de preenchimento especificado. Cada borda do retângulo de preenchimento é definida por um deslocamento percentual em relação à borda correspondente da caixa delimitadora da forma. Um percentual positivo indica recuo; um percentual negativo indica extensão.

1. Crie uma instância da [classe Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).  
2. Obtenha a referência de um slide pelo seu índice.  
3. Adicione um retângulo `AutoShape`.  
4. Crie uma imagem.  
5. Defina o tipo de preenchimento da forma.  
6. Defina o modo de preenchimento da imagem da forma.  
7. Adicione uma imagem de preenchimento à forma.  
8. Defina os deslocamentos da imagem em relação às bordas correspondentes da caixa delimitadora da forma.  
9. Grave a apresentação modificada como um arquivo PPTX.  

Este código C++ demonstra um processo em que a propriedade StretchOff é usada:

```cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Define que a imagem seja esticada a partir de cada lado no corpo da forma
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Como descobrir quais formatos de imagem são suportados por PictureFrame?**

O Aspose.Slides suporta tanto imagens raster (PNG, JPEG, BMP, GIF etc.) quanto imagens vetoriais (por exemplo, SVG) por meio do objeto de imagem atribuído a um [PictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pictureframe/). A lista de formatos suportados normalmente coincide com as capacidades do mecanismo de conversão de slides e imagens.

**Como a adição de dezenas de imagens grandes afetará o tamanho e o desempenho do PPTX?**

Incorporar imagens grandes aumenta o tamanho do arquivo e o uso de memória; vincular imagens ajuda a manter o tamanho da apresentação reduzido, mas requer que os arquivos externos permaneçam acessíveis. O Aspose.Slides oferece a possibilidade de adicionar imagens por link para reduzir o tamanho do arquivo.

**Como bloquear um objeto de imagem contra movimentação/redimensionamento acidental?**

Use [travas de forma](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pictureframe/get_pictureframelock/) para um [PictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pictureframe/) (por exemplo, desativar movimentação ou redimensionamento). O mecanismo de trava é descrito para formas em um [artigo de proteção separado](/slides/pt/cpp/applying-protection-to-presentation/) e é compatível com vários tipos de forma, incluindo [PictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pictureframe/).

**A fidelidade vetorial do SVG é preservada ao exportar uma apresentação para PDF/imagens?**

O Aspose.Slides permite extrair um SVG de um [PictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/pictureframe/) como o vetor original. Ao [exportar para PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/) ou [formatos raster](/slides/pt/cpp/convert-powerpoint-to-png/), o resultado pode ser rasterizado dependendo das configurações de exportação; o fato de que o SVG original é armazenado como vetor é confirmado pelo comportamento de extração.