---
title: Mesclar apresentações de forma eficiente em C++
linktitle: Mesclar apresentações
type: docs
weight: 40
url: /pt/cpp/merge-presentation/
keywords:
- mesclar PowerPoint
- mesclar apresentações
- mesclar slides
- mesclar PPT
- mesclar PPTX
- mesclar ODP
- combinar PowerPoint
- combinar apresentações
- combinar slides
- combinar PPT
- combinar PPTX
- combinar ODP
- C++
- Aspose.Slides
description: "Mescle apresentações PowerPoint (PPT, PPTX) e OpenDocument (ODP) de forma fácil com Aspose.Slides para C++, simplificando seu fluxo de trabalho."
---
## **Visão geral**

Aspose.Slides permite mesclar apresentações clonando slides de uma apresentação para outra. Este artigo explica como mesclar apresentações completas ou slides selecionados, usar um mestre de slides ou um layout específico durante a mesclagem, lidar com apresentações com tamanhos de slide diferentes e adicionar slides mesclados a uma seção da apresentação. Também aborda notas práticas relacionadas ao conteúdo mesclado, incluindo notas do apresentador, comentários, arquivos de origem protegidos por senha e uso de threads.

## **Mesclagem de apresentações**

Ao mesclar uma apresentação em outra, você combina efetivamente seus slides em uma única apresentação para obter um único arquivo. 

{{% alert title="Informação" color="info" %}}

A maioria dos programas de apresentação (PowerPoint ou OpenOffice) não possui funções que permitam aos usuários combinar apresentações dessa forma. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/pt/cpp/) , entretanto, permite mesclar apresentações de diferentes maneiras. Você pode mesclar apresentações com todas as suas formas, estilos, textos, formatações, comentários, animações etc. sem se preocupar com perda de qualidade ou de dados. 

**Veja também**

[Clone Slides](https://docs.aspose.com/slides/pt/cpp/clone-slides/)*.* 

{{% /alert %}}

### **O que pode ser mesclado**

Com Aspose.Slides, você pode mesclar 

* apresentações completas. Todos os slides das apresentações terminam em uma única apresentação
* slides específicos. Slides selecionados terminam em uma única apresentação
* apresentações em um formato (PPT para PPT, PPTX para PPTX, etc.) e em formatos diferentes (PPT para PPTX, PPTX para ODP, etc.) entre si. 

{{% alert title="Observação" color="warning" %}} 

Além de apresentações, Aspose.Slides permite mesclar outros arquivos:

* [Imagens](https://products.aspose.com/slides/pt/cpp/merger/image-to-image/), como [JPG para JPG](https://products.aspose.com/slides/pt/cpp/merger/jpg-to-jpg/) ou [PNG para PNG](https://products.aspose.com/slides/pt/cpp/merger/png-to-png/)
* Documentos, como [PDF para PDF](https://products.aspose.com/slides/pt/cpp/merger/pdf-to-pdf/) ou [HTML para HTML](https://products.aspose.com/slides/pt/cpp/merger/html-to-html/)
* E dois arquivos diferentes, como [imagem para PDF](https://products.aspose.com/slides/pt/cpp/merger/image-to-pdf/) ou [JPG para PDF](https://products.aspose.com/slides/pt/cpp/merger/jpg-to-pdf/) ou [TIFF para PDF](https://products.aspose.com/slides/pt/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opções de mesclagem**

Você pode aplicar opções que determinam se

* cada slide na apresentação de saída mantém um estilo exclusivo
* um estilo específico é usado para todos os slides na apresentação de saída. 

Para mesclar apresentações, Aspose.Slides fornece métodos [AddClone](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (da interface [ISlideCollection](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_slide_collection)). Existem várias implementações dos métodos `AddClone` que definem os parâmetros do processo de mesclagem de apresentação. Cada objeto Presentation possui uma coleção [Slides](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), portanto você pode chamar um método `AddClone` a partir da apresentação na qual deseja mesclar slides. 

O método `AddClone` devolve um objeto `ISlide`, que é um clone do slide de origem. Os slides na apresentação de saída são simplesmente uma cópia dos slides da origem. Portanto, você pode fazer alterações nos slides resultantes (por exemplo, aplicar estilos, opções de formatação ou layouts) sem se preocupar com impactos nas apresentações de origem. 

## **Mesclar apresentações** 

Aspose.Slides fornece o método [**AddClone (ISlide)**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) que permite combinar slides enquanto eles mantêm seus layouts e estilos (parâmetros padrão). 

Este código C++ mostra como mesclar apresentações:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Mesclar apresentações com um mestre de slides**

Aspose.Slides fornece o método [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) que permite combinar slides aplicando um modelo de mestre de slides. Dessa forma, se necessário, você pode mudar o estilo dos slides na apresentação de saída. 

Este código em C++ demonstra a operação descrita:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Observação" color="warning" %}} 

O layout de slide para o mestre é determinado automaticamente. Quando um layout apropriado não pode ser determinado, se o parâmetro booleano `allowCloneMissingLayout` do método `AddClone` estiver definido como true, o layout do slide de origem será usado. Caso contrário, será lançada a exceção [PptxEditException](https://reference.aspose.com/slides/pt/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 

{{% /alert %}}

Se você quiser que os slides na apresentação de saída tenham um layout de slide diferente, use o método [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) ao mesclar. 

## **Mesclar slides específicos de apresentações**

Mesclar slides específicos de várias apresentações é útil para criar decks de slides personalizados. Aspose.Slides C++ permite selecionar e importar apenas os slides que você precisa. A API preserva a formatação, o layout e o design dos slides originais.

O código C++ a seguir cria uma nova apresentação, adiciona slides de título de duas outras apresentações e salva o resultado em um arquivo:

```cpp
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Mesclar apresentações com um layout de slide**

Este código C++ mostra como combinar slides de apresentações aplicando o layout de slide preferido para obter uma única apresentação de saída:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Mesclar apresentações com tamanhos de slide diferentes**

{{% alert title="Observação" color="warning" %}} 

Não é possível mesclar apresentações com tamanhos de slide diferentes. 

{{% /alert %}}

Para mesclar 2 apresentações com tamanhos de slide diferentes, você deve redimensionar uma das apresentações para que seu tamanho corresponda ao da outra. 

Este código de exemplo demonstra a operação descrita:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Mesclar slides em uma seção da apresentação**

Este código C++ mostra como mesclar um slide específico em uma seção de uma apresentação:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

O slide é adicionado ao final da seção. 

{{% alert title="Dica" color="primary" %}}

A Aspose oferece um [aplicativo web GRATUITO de Colagem](https://products.aspose.app/slides/pt/collage). Usando este serviço online, você pode mesclar [JPG para JPG](https://products.aspose.app/slides/pt/collage/jpg) ou PNG para PNG, criar [grades de fotos](https://products.aspose.app/slides/pt/collage/photo-grid) etc. 

{{% /alert %}}

## **FAQ**

**As notas do apresentador são preservadas durante a mesclagem?**

Sim. Ao clonar slides, Aspose.Slides transporta todos os elementos do slide, incluindo notas, formatação e animações.

**Os comentários e seus autores são transferidos?**

Os comentários, como parte do conteúdo do slide, são copiados junto com o slide. Os rótulos de autor dos comentários são preservados como objetos de comentário na apresentação resultante.

**E se a apresentação de origem estiver protegida por senha?**

Ela deve ser [aberta com a senha](/slides/pt/cpp/password-protected-presentation/) via [LoadOptions::set_Password](https://reference.aspose.com/slides/pt/cpp/aspose.slides/loadoptions/set_password/); após o carregamento, esses slides podem ser clonados com segurança para um arquivo de destino não protegido (ou também protegido).

**Quão segura é a operação de mesclagem em relação a threads?**

Não use a mesma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) a partir de [múltiplas threads](/slides/pt/cpp/multithreading/). A regra recomendada é “um documento — uma thread”; arquivos diferentes podem ser processados em paralelo em threads distintas.