---
title: Gerenciar quadros de imagem em apresentações usando C++
linktitle: Quadro de imagem
type: docs
weight: 10
url: /pt/cpp/picture-frame/
keywords:
- quadro de imagem
- adicionar quadro de imagem
- criar quadro de imagem
- imagem incorporada
- imagem vinculada
- extrair imagem
- imagem raster
- imagem SVG
- recortar imagem
- excluir áreas recortadas
- compactar imagem
- StretchOffset
- formatação de quadro de imagem
- escala relativa
- efeito de imagem
- proporção de aspecto
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Criar, formatar, vincular, recortar, extrair e compactar quadros de imagem em apresentações com Aspose.Slides para C++."
---
## **Visão geral**

Um quadro de imagem é uma forma de slide que exibe uma imagem. No Aspose.Slides, o recurso de imagem e a forma que a exibe são objetos separados: um [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) possui recursos de imagem incorporados por meio de sua [image collection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/get_images/), enquanto um [IPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframe/) controla a posição, o tamanho, a formatação de linha, rotação, recorte, efeitos de imagem e outras configurações ao nível do quadro.

Essa separação é útil quando a mesma imagem é exibida mais de uma vez. Adicione a imagem à apresentação uma única vez, mantenha o [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) retornado e use esse recurso de imagem ao criar quadros de imagem.

Quadros de imagem podem conter imagens raster, como PNG ou JPEG, e imagens vetoriais SVG. Eles também podem referenciar imagens vinculadas em vez de armazenar os bytes da imagem na apresentação. A escolha afeta a portabilidade, o tamanho do arquivo, a extração e o comportamento de exportação, por isso é útil decidir como a imagem deve ser armazenada antes de aplicar formatação ou otimização.

## **Adicionar e formatar uma imagem incorporada**

Para uma imagem incorporada, adicione os dados da imagem à apresentação e crie um quadro de imagem com [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/shapecollection/addpictureframe/). A imagem passa a fazer parte do pacote da apresentação, de modo que a apresentação permanece autocontida quando é movida para outro computador.

O exemplo a seguir adiciona uma imagem JPEG, cria um quadro nas dimensões nativas da imagem e aplica formatação de linha e rotação:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O quadro de imagem controla a geometria exibida; alterar o tamanho do quadro não altera as dimensões de pixel originais armazenadas no recurso de imagem incorporado. Essa distinção torna‑se importante ao recortar ou comprimir uma imagem posteriormente.

## **Usar escala relativa**

[IPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframe/) expõe escalonamento relativo de largura e altura para o quadro. Um valor de `1.0` corresponde a 100 % do tamanho original da imagem. A escala relativa é útil quando um fluxo de trabalho precisa preservar uma relação com o tamanho da imagem de origem em vez de calcular dimensões finais manualmente.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A escala relativa altera as configurações de escala do quadro; não reamostra nem comprime a imagem incorporada.

## **Imagens incorporadas e vinculadas**

Uma imagem incorporada armazena os dados da imagem dentro da apresentação e, portanto, é a escolha mais segura para portabilidade e renderização previsível. Uma imagem vinculada armazena um local externo por meio do caminho de link do [ISlidesPicture](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidespicture/) em vez de incorporar os dados da imagem da mesma forma.

Imagens vinculadas podem reduzir a quantidade de dados de imagem armazenados no PPTX, mas introduzem uma dependência externa. O arquivo vinculado deve permanecer acessível à aplicação que abre ou renderiza a apresentação. Se o caminho mudar, o arquivo for movido ou o recurso ficar indisponível, a imagem vinculada pode não ser exibida como esperado. Para apresentações que precisam ser enviadas por e‑mail, arquivadas ou renderizadas em ambientes isolados, imagens incorporadas geralmente são mais confiáveis.

### **Adicionar uma imagem vinculada**

O exemplo a seguir cria um quadro de imagem e aponta para um arquivo de imagem local. Ele trata apenas do vínculo de imagem; o vínculo de vídeo é um fluxo de mídia separado e deliberadamente não foi misturado neste exemplo.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Use vínculos quando a gestão de arquivos externos for intencional. Não os use apenas como substituto para compressão: um PPTX pequeno com dependências de imagem quebradas costuma ser menos útil que uma apresentação maior e autocontida.

## **Extrair imagens dos quadros de imagem**

Antes de extrair uma imagem de uma apresentação existente, verifique se uma forma é realmente um [IPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframe/) e se ela contém uma imagem incorporada. Quadros de imagem vinculados podem não conter bytes de imagem que possam ser extraídos da mesma forma.

### **Extrair uma imagem raster**

A API de imagem moderna usa [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) diretamente. O exemplo a seguir encontra a primeira imagem raster incorporada em um slide e a salva como PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

Salvar por meio de [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) converte a imagem extraída para o formato de saída solicitado. Se precisar dos bytes codificados armazenados na apresentação em vez de um arquivo raster convertido, use os dados binários do recurso de imagem.

### **Extrair uma imagem SVG**

Para uma imagem SVG, o [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) expõe um objeto [ISvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/). Isso permite recuperar os dados SVG diretamente, sem rasterizar a imagem primeiro.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

Manter o conteúdo SVG como SVG preserva a origem vetorial dentro da apresentação. Exportações raster, como PNG ou JPEG, necessariamente renderizam esse conteúdo vetorial em pixels. A exportação de slides em PDF ou SVG também é uma operação de renderização, portanto os gráficos exportados não devem ser tratados como uma cópia byte‑a‑byte do SVG incorporado original; use os dados do [ISvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/) incorporado quando o recurso vetorial original for necessário.

## **Recortar uma imagem**

O recorte altera qual parte da imagem está visível dentro do quadro. Os valores de recorte em [IPictureFillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/) são percentuais das dimensões da imagem de origem. O recorte não exclui inicialmente os pixels ocultos da imagem incorporada; ele apenas altera a região visível.

O exemplo a seguir encontra um quadro de imagem com segurança e aplica valores de recorte:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Como os dados da imagem oculta ainda permanecem, o recorte pode ser alterado posteriormente sem perder os pixels originais. Se o tamanho do arquivo for mais importante que a reversibilidade, as regiões recortadas podem ser removidas fisicamente conforme descrito na seção seguinte.

## **Remover dados de imagem recortados**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) remove os dados da imagem fora do retângulo de recorte atual e devolve o recurso de imagem resultante. Isso pode reduzir o tamanho do arquivo, mas é uma otimização destrutiva: após salvar a apresentação, os pixels removidos não ficam mais disponíveis para uma operação de desrecorte posterior.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

O método pode adicionar um novo recurso de imagem à apresentação. Se a imagem original também for usada por outros quadros de imagem, esses quadros ainda precisarão do recurso existente, de modo que excluir áreas recortadas não reduz necessariamente o número total de imagens. Recortar conteúdo WMF ou EMF com este método rasteriza o resultado recortado para PNG.

## **Comprimir imagens raster**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/compressimage/) reduz a resolução da imagem raster em relação ao tamanho no qual a imagem é exibida. Também pode remover regiões recortadas na mesma operação. O método devolve `true` quando a imagem foi redimensionada ou recortada e `false` quando nenhuma alteração foi necessária.

Use um valor pré‑definido de [PicturesCompression](https://reference.aspose.com/slides/pt/cpp/aspose.slides.export/picturescompression/) quando uma resolução alvo padrão for suficiente:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Um valor DPI positivo personalizado pode ser passado em vez de um valor de enumeração quando um alvo específico for necessário.

A compressão destina‑se a imagens raster. Conteúdo SVG e metafile não é reduzido por este fluxo de compressão raster. Também lembre‑se de que resolução mais baixa e regiões recortadas excluídas não podem ser recuperadas da apresentação otimizada. Escolha uma resolução alvo com base no maior tamanho em que a imagem será realmente visualizada ou exportada, em vez de aplicar o DPI mais baixo globalmente.

## **Gerenciar efeitos de transformação de imagem**

Para um fluxo de trabalho completo que cubra brilho, contraste, transformações de cor, desfoque, efeitos alfa, cadeias ordenadas, inspeção, remoção e verificação de ida e volta, veja [Image Transform Effects](/slides/pt/cpp/image-transform-effects/).

## **Bloquear a geometria do quadro de imagem**

As configurações de [IPictureFrameLock](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframelock/) controlam quais operações de edição são desativadas para um quadro de imagem. Por exemplo, o [aspect‑ratio lock](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) preserva as proporções da forma enquanto ela é redimensionada.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O bloqueio se aplica à forma do quadro de imagem. Não força que a imagem de origem seja reamostrada ou permanentemente alterada para a mesma proporção.

## **Ajustar os valores StretchOffset**

Quando o modo de preenchimento da imagem é stretch, os valores stretch‑offset em [IPictureFillFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/) definem o retângulo de preenchimento relativo à caixa delimitadora do quadro de imagem. Percentuais positivos criam um recuo a partir de uma borda, enquanto percentuais negativos criam um extravasamento.

Isso difere do recorte. Valores de recorte selecionam qual parte da imagem de origem fica visível; offsets de stretch alteram o retângulo no qual o preenchimento visível da imagem é esticado.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Use offset de stretch para posicionamento de preenchimento. Use propriedades de recorte quando o objetivo for ocultar as bordas da imagem de origem.

## **Armazenamento, tamanho de arquivo e considerações de exportação**

Os principais trade‑offs são mais fáceis de gerir quando o armazenamento de imagens e a formatação do quadro de imagem são tratados separadamente:

- **Imagens incorporadas** deixam a apresentação autocontida e são as mais confiáveis para compartilhamento e renderização no servidor, porém imagens raster grandes aumentam o tamanho do PPTX e o uso de memória.
- **Imagens vinculadas** podem manter o pacote menor, mas a apresentação depende de arquivos externos permanecendo disponíveis nos caminhos ou locais armazenados.
- **Recorte** é inicialmente não destrutivo. Os pixels ocultos permanecem incorporados até que áreas recortadas sejam explicitamente excluídas ou removidas durante a compressão.
- **Compressão** pode reduzir substancialmente o tamanho do arquivo para imagens raster excessivamente grandes, mas sacrifica a resolução original. Deve ser aplicada após conhecer o tamanho final desejado na tela.
- **Imagens SVG** devem permanecer como SVG quando a preservação vetorial for importante. Extraia o SVG incorporado diretamente quando precisar do recurso vetorial em si. Exportações de slides raster sempre convertem o slide renderizado em pixels.
- **Imagens repetidas** devem reutilizar um recurso [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) existente sempre que possível, em vez de carregar repetidamente o mesmo arquivo no fluxo de trabalho da apresentação.

Para apresentações grandes, a otimização de imagens costuma ser mais eficaz quando feita seletivamente: mantenha logotipos e diagramas como conteúdo vetorial, comprima fotografias de acordo com seu tamanho real de exibição, remova pixels recortados somente quando a edição posterior não for necessária e evite vínculos externos a menos que a gestão de dependências faça parte do design de implantação.

## **FAQ**

**Qual a diferença entre um quadro de imagem e um recurso de imagem?**

Um [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) representa um recurso de imagem associado à apresentação. Um [IPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframe/) é uma forma em um slide que exibe uma imagem e armazena geometria e formatação ao nível do quadro, como tamanho, rotação, valores de recorte, efeitos e bloqueios.

**Devo incorporar ou vincular imagens?**

Incorpore imagens quando a apresentação precisar ser portátil, arquivada ou renderizada sem acesso a recursos externos. Vincule imagens somente quando manter os arquivos de imagem fora do PPTX for intencional e os locais externos puderem ser mantidos de forma confiável.

**O recorte reduz o tamanho do arquivo PPTX?**

Não por si só. Configurações normais de recorte ocultam partes da imagem de origem, mas mantêm os pixels subjacentes. Use [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ou compressão de imagem com remoção de áreas recortadas quando esses pixels puderem ser descartados permanentemente.

**Posso restaurar a qualidade da imagem após a compressão?**

Não. A compressão pode reduzir a resolução raster armazenada e a remoção de regiões recortadas descarta dados da imagem. Mantenha a imagem original fora da apresentação se edições de alta resolução posteriores forem necessárias.

**Como devo tratar imagens SVG?**

Mantenha o conteúdo SVG como SVG quando a fidelidade vetorial for relevante. O [ISvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/) incorporado pode ser extraído diretamente. Renderizar um slide para um formato raster como PNG ou JPEG rasteriza o SVG como parte da imagem do slide.

**Como evitar casts inseguros ao ler slides existentes?**

Verifique o tipo da forma antes de usar membros específicos de quadro de imagem. Teste a forma com [IPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframe/) antes de aplicar um cast em tempo de execução e atribua o resultado do cast a uma variável local antes de acessar membros específicos de quadro de imagem.