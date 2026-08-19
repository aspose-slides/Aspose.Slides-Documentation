---
title: Otimizar o gerenciamento de imagens em apresentações usando C++
linktitle: Gerenciar Imagens
type: docs
weight: 10
url: /pt/cpp/image/
keywords:
- adicionar imagem
- adicionar foto
- substituir imagem
- coleção de imagens
- quadro de imagem
- imagem vinculada
- plano de fundo
- adicionar PNG
- adicionar JPG
- adicionar SVG
- SVG para formas
- recursos SVG externos
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a adicionar, reutilizar, vincular, substituir e gerenciar imagens raster e SVG em apresentações PowerPoint e OpenDocument com Aspose.Slides para C++."
---
## **Introdução**

O Aspose.Slides for C++ oferece várias maneiras de trabalhar com imagens, e cada uma serve a um propósito diferente. Você pode armazenar uma imagem em uma apresentação, exibí‑la em um quadro de imagem, usá‑la como plano de fundo de slide, vincular a uma imagem externa, substituir um recurso de imagem compartilhado ou converter conteúdo SVG em formas editáveis.

Este artigo foca nos recursos de imagem e como eles são usados em toda a apresentação. Para corte, transparência, efeitos, alongamento e outras formatações aplicadas a um quadro de imagem individual, veja [Picture Frame](/slides/pt/cpp/picture-frame/).

## **Entenda o Modelo de Imagem**

- A [presentation image collection](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimagecollection/) armazena recursos de imagem usados pela apresentação. Use [IImageCollection::AddImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimagecollection/addimage/) para adicionar dados de imagem e obter um recurso [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/).
- Um [picture frame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipictureframe/) é uma forma que exibe uma imagem em um slide, layout ou mestre. Use [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addpictureframe/) para posicionar um recurso de imagem em um slide.
- Um plano de fundo de slide usa uma imagem como parte do preenchimento do slide, e não como uma forma. Portanto, não se comporta como um picture frame.
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/replaceimage/) substitui um recurso de imagem. Se vários elementos da apresentação usarem esse recurso, todos usarão a substituição.
- Converter um SVG em formas cria formas de slide editáveis. Após a conversão, o conteúdo deixa de ser gerenciado como um único recurso de imagem.

Um fluxo de trabalho típico, portanto, é o seguinte: adicione dados de imagem à coleção de imagens, receba um [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/), e então use esse recurso em um ou mais picture frames ou preenchimentos.

## **Adicionar uma Imagem Incorporada**

Para inserir uma imagem local, leia o arquivo, adicione seus dados à coleção de imagens e crie um picture frame que use o recurso [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) retornado.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A imagem adicionada dessa forma fica incorporada na apresentação, de modo que o arquivo resultante não depende da disponibilidade contínua do arquivo de imagem original.

### **Adicionar uma Imagem da Web**

Quando uma imagem está disponível via HTTP ou HTTPS, faça o download de seus bytes, adicione‑os à coleção de imagens da apresentação e use o recurso de imagem retornado da mesma forma que uma imagem local.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Valide URLs remotas, tamanhos de resposta e tipos de conteúdo quando a origem não for confiável. Em aplicativos que já utilizam outro cliente HTTP, você pode baixar a imagem com esse cliente e passar os bytes ou o fluxo resultante para [IImageCollection::AddImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimagecollection/addimage/).

## **Reutilizar Imagens em Vários Slides**

Se a mesma imagem for necessária mais de uma vez, adicione‑a à apresentação uma única vez e reutilize o [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) retornado ao criar picture frames adicionais. Isso evita carregar repetidamente os mesmos dados de origem e torna explícita a relação entre o recurso de imagem compartilhado e seus usos.

Para gráficos que devem aparecer automaticamente em muitos slides, como o logotipo da empresa, considere colocar o picture frame em um [slide master](/slides/pt/cpp/slide-master/) ou layout em vez de adicionar uma forma equivalente a cada slide.

## **Usar uma Imagem como Plano de Fundo de Slide**

Uma imagem de fundo é atribuída ao preenchimento do slide; ela não é adicionada como uma forma de picture frame. Isso é útil quando a imagem deve cobrir o fundo do slide e não deve ser manipulada como um objeto de slide normal.

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para opções adicionais de fundo, incluindo fundos de mestre e layout, veja [Presentation Background](/slides/pt/cpp/presentation-background/).

## **Imagens Incorporadas e Imagens Vinculadas**

Imagens incorporadas e vinculadas têm diferentes compensações de portabilidade e tamanho de arquivo:

- **Imagem incorporada:** os dados da imagem são armazenados dentro da apresentação. A apresentação é autônoma, mas o tamanho do arquivo inclui os dados da imagem.
- **Imagem vinculada:** a apresentação armazena um caminho ou URL para uma imagem externa. Isso pode reduzir o tamanho da apresentação, mas o recurso externo deve permanecer acessível quando a apresentação for aberta ou renderizada.

Uma imagem vinculada pode ser criada atribuindo o caminho ou URL externo através de [ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/pt/cpp/aspose.slides/islidespicture/set_linkpathlong/) em vez de incorporar os dados da imagem.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Utilize imagens vinculadas apenas quando o ambiente de implantação puder acessar o recurso externo de forma confiável. Para apresentações que precisam funcionar offline ou serem transferidas entre sistemas, imagens incorporadas são geralmente mais seguras.

## **Trabalhar com Imagens SVG**

SVG é um formato vetorial, portanto pode ser útil para ícones, diagramas e outras imagens que devem escalar sem a mesma perda de detalhes que imagens raster. O Aspose.Slides oferece suporte a SVG tanto como recurso de imagem quanto como fonte para formas de slide editáveis.

### **Adicionar um SVG como Imagem**

Crie um [SvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/svgimage/), adicione‑o à coleção de imagens e coloque o recurso de imagem resultante em um picture frame.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Arquivos SVG com Recursos Externos**

Um SVG pode referenciar imagens, folhas de estilo ou fontes externas. Para esses casos, [SvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/svgimage/) fornece construtores que aceitam um [IExternalResourceResolver](https://reference.aspose.com/slides/pt/cpp/aspose.slides.import/iexternalresourceresolver/) e uma URI base. O resolvedor pode mapear uma URI relativa para uma URI absoluta permitida e retornar um fluxo para o recurso solicitado.

O resolvedor disponibiliza recursos externos enquanto o Aspose.Slides processa o SVG, mas não reescreve o SVG em um documento autônomo. Se o SVG precisar permanecer portátil, incorpore seus recursos necessários no próprio SVG, por exemplo usando URIs `data:` para imagens vinculadas.

Quando arquivos SVG provêm de fontes não confiáveis, restrinja os esquemas, locais de arquivos e hosts que o resolvedor pode acessar. Resolvedores de rede também devem aplicar limites de tempo, tamanho de resposta e validação de conteúdo.

### **Converter SVG em Formas Editáveis**

O Aspose.Slides pode converter um SVG em um grupo de formas de slide editáveis, semelhante ao comando correspondente do PowerPoint.

![Menu Pop-up do PowerPoint](img_01_01.png)

Use uma sobrecarga de [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addgroupshape/) que aceita um [ISvgImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/isvgimage/) para realizar a conversão.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Use a conversão de SVG para formas quando elementos vetoriais individuais precisarem ser editados como formas do PowerPoint. Se o SVG precisar apenas ser exibido, mantê‑lo como imagem é mais simples e evita a criação de muitas formas separadas.

## **Substituir um Recurso de Imagem Existente**

Use [IPPImage::ReplaceImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/replaceimage/) quando quiser substituir um recurso de imagem existente. Isso é especialmente útil para gráficos compartilhados, como logotipos.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Se vários picture frames, fundos, mestres ou layouts usarem o mesmo recurso de imagem, substituir esse recurso atualiza todos esses usos. Se apenas um picture frame deve mudar, atribua uma imagem diferente a esse frame em vez de substituir o recurso compartilhado.

[IPPImage::ReplaceImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/replaceimage/) também oferece sobrecargas que aceitam um [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) ou outro [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/).

## **Orientações Práticas de Gerenciamento de Imagens**

### **Controlar o Tamanho da Apresentação**

Imagens raster grandes podem tornar uma apresentação desnecessariamente grande. Use imagens de origem com dimensões adequadas ao tamanho de exibição previsto, reutilize recursos de imagem compartilhados sempre que possível e evite incorporar cópias repetidas do mesmo gráfico em alta resolução.

Para imagens raster que já foram colocadas em picture frames, [IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipicturefillformat/compressimage/) pode reduzir os dados da imagem de acordo com a resolução selecionada e as configurações de corte. Isso é um processamento de picture frame, não de gerenciamento da coleção de imagens, portanto consulte [Picture Frame](/slides/pt/cpp/picture-frame/) para operações de formatação relacionadas.

### **Escolher Entre Conteúdo Incorporado e Vinculado**

Incorporar torna a apresentação portátil porque todos os dados de imagem necessários viajam com o arquivo. Vincular pode reduzir o tamanho do arquivo, mas introduz uma dependência externa. Use links somente quando essa dependência for aceitável e estável.

### **Reutilizar Marca Compartilhada**

Para logotipos, marcas d'água ou gráficos decorativos repetidos, use um recurso de imagem e reutilize‑o. Se o gráfico fizer parte do design da apresentação e não do conteúdo dos slides, coloque‑o em um mestre ou layout para que seja herdado pelos slides apropriados.

### **Manter Recursos SVG Portáteis**

Um SVG autônomo é mais fácil de mover e renderizar de forma consistente do que um SVG que depende de arquivos externos ou recursos de rede. Quando possível, incorpore os recursos necessários antes de importar o SVG. Converta SVG em formas somente quando os elementos vetoriais individuais precisarem ser editados.

### **Usar a API de Imagem do Aspose.Slides**

Para fluxos de trabalho de imagem em C++, use as APIs [IImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimage/) e [Images](https://reference.aspose.com/slides/pt/cpp/aspose.slides/images/) do Aspose.Slides quando precisar de um objeto de imagem, e use [IImageCollection::AddImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimagecollection/addimage/) quando precisar registrar dados de imagem como recurso da apresentação. As sobrecargas da coleção também suportam arrays de bytes e streams, o que é útil quando os dados da imagem provêm de arquivos, clientes de rede, bancos de dados ou outras bibliotecas.

Gerar conteúdo EMF a partir de planilhas ou de outro produto é um fluxo de integração separado e está fora do escopo deste artigo. Se um arquivo WMF ou EMF existente precisar apenas ser inserido em uma apresentação, passe seus dados para uma sobrecarga apropriada de [IImageCollection::AddImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iimagecollection/addimage/) sem adicionar uma dependência de um segundo produto ao fluxo de gerenciamento de imagens.

## **FAQ**

**Qual é a diferença entre a coleção de imagens e um picture frame?**

A coleção de imagens armazena recursos de imagem reutilizáveis. Um picture frame é uma forma de slide que exibe um desses recursos e fornece formatações específicas de imagem, como corte e efeitos.

**Qual é a melhor maneira de substituir o mesmo logotipo em todos os lugares?**

Se o logotipo já estiver compartilhado como um recurso de imagem, substitua esse recurso com [IPPImage::ReplaceImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/replaceimage/). Para branding em toda a apresentação, colocar o logotipo em um mestre ou layout também pode reduzir o conteúdo duplicado dos slides.

**Por que uma imagem vinculada desaparece em outro computador?**

Uma imagem vinculada depende de seu arquivo ou URL externo. Se esse recurso não puder ser acessado a partir do outro computador, a imagem vinculada pode ficar indisponível. Incorpore a imagem quando a apresentação precisar ser autônoma.

**É possível editar um SVG inserido como formas do PowerPoint?**

Sim. Converta o SVG com [IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ishapecollection/addgroupshape/); o grupo resultante contém formas de slide editáveis em vez de uma única imagem SVG.

**Como posso manter apresentações com muitas imagens menores?**

Reutilize recursos de imagem compartilhados, evite fontes raster desnecessariamente grandes, comprima imagens raster adequadas quando apropriado, mantenha a marca repetida em mestres ou layouts e use imagens vinculadas somente quando uma dependência externa for aceitável.