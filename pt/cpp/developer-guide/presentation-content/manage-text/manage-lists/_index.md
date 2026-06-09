---
title: Gerenciar Listas com Marcadores e Numeradas em Apresentações em C++
linktitle: Gerenciar Listas
type: docs
weight: 70
url: /pt/cpp/manage-lists/
keywords:
- marcador
- lista com marcadores
- lista numerada
- marcador de símbolo
- marcador de imagem
- marcador personalizado
- lista multinível
- criar marcador
- adicionar marcador
- adicionar lista
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Aprenda a criar e formatar listas com marcadores, imagens, multinível e numeradas em apresentações PowerPoint e OpenDocument usando Aspose.Slides para C++."
---
## **Visão geral**

Aspose.Slides for C++ permite criar e formatar listas com marcadores e numeradas em apresentações PowerPoint e OpenDocument. Um item de lista é um parágrafo cujas configurações de marcador são controladas através do seu formato de parágrafo.

Use o método [IParagraph::get_ParagraphFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraph/get_paragraphformat/) para acessar as configurações de lista no nível do parágrafo. O ponto de entrada principal é [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/get_bullet/), que devolve um objeto [IBulletFormat](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/). Com esse objeto, você pode definir o tipo de marcador, símbolo, imagem, cor, tamanho, estilo de numeração e número inicial.

Este artigo mostra como:

- criar uma lista com marcadores usando um símbolo personalizado
- criar um marcador de imagem
- criar uma lista multinível definindo a profundidade do parágrafo
- criar uma lista numerada
- inspecionar e alterar a formatação de lista em uma apresentação existente

## **Criar uma lista com marcadores**

Para criar uma lista com marcadores, adicione objetos [Paragraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides/paragraph/) a um [ITextFrame](https://reference.aspose.com/slides/pt/cpp/aspose.slides/itextframe/) e defina [IBulletFormat::set_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_type/) como [BulletType::Symbol](https://reference.aspose.com/slides/pt/cpp/aspose.slides/bullettype/). Em seguida, você pode definir [IBulletFormat::set_Char](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_char/), [IBulletFormat::get_Color](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/get_color/) e [IBulletFormat::set_Height](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_height/) para controlar a aparência do marcador.

O código C++ a seguir demonstra como criar uma lista com marcadores em um slide:

```cpp
auto createParagraph = [](System::String text)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Symbol);
    bulletFormat->set_Char(u'*');
    paragraphFormat->set_Indent(15);
    bulletFormat->set_IsBulletHardColor(NullableBool::True);
    bulletFormat->get_Color()->set_Color(System::Drawing::Color::get_IndianRed());
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = createParagraph(u"The first paragraph");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph");
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"symbol_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The symbol bullets](symbol_bullets.png)

## **Criar uma lista numerada**

Use listas numeradas quando a ordem dos itens for importante. Defina [IBulletFormat::set_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_type/) como [BulletType::Numbered](https://reference.aspose.com/slides/pt/cpp/aspose.slides/bullettype/). Você também pode escolher um formato de numeração com [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) ou definir [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) quando a lista deve iniciar a partir de um valor diferente de 1.

O código C++ a seguir mostra como criar uma lista numerada em um slide:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph1->set_Text(u"Apple");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph2->set_Text(u"Orange");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
paragraph3->set_Text(u"Banana");
textFrame->get_Paragraphs()->Add(paragraph3);

presentation->Save(u"numbered_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The numbered bullets](numbered_bullets.png)

## **Criar um marcador de imagem**

Aspose.Slides permite substituir um símbolo de marcador padrão por uma imagem. Marcadores de imagem funcionam melhor com imagens simples que permanecem legíveis em tamanho pequeno, como ícones ou arquivos PNG transparentes.

{{% alert color="primary" %}}

Idealmente, se você planeja substituir o símbolo de marcador padrão por uma imagem, escolha um gráfico simples com fundo transparente. Essas imagens funcionam bem como símbolos de marcadores personalizados.

Lembre-se de que a imagem será reduzida a um tamanho muito pequeno. Por esse motivo, recomendamos fortemente selecionar uma imagem que permaneça clara e visualmente eficaz quando usada como marcador em uma lista.

{{% /alert %}}

Para criar um marcador de imagem, adicione uma imagem a [IPresentation::get_Images](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ipresentation/get_images/) e atribua o objeto [IPPImage](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ippimage/) retornado a [IBulletFormat::get_Picture](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/get_picture/). Defina [IBulletFormat::set_Type](https://reference.aspose.com/slides/pt/cpp/aspose.slides/ibulletformat/set_type/) como [BulletType::Picture](https://reference.aspose.com/slides/pt/cpp/aspose.slides/bullettype/) antes de atribuir a imagem.

Suponha que temos um “image.png”:

![A picture for the bullets](picture_for_bullets.png)

O código C++ a seguir mostra como criar marcadores de imagem em um slide:

```cpp
auto createParagraph = [](System::String text, System::SharedPtr<IPPImage> image)
{
    auto paragraph = System::MakeObject<Paragraph>();
    auto paragraphFormat = paragraph->get_ParagraphFormat();
    auto bulletFormat = paragraphFormat->get_Bullet();

    bulletFormat->set_Type(BulletType::Picture);
    bulletFormat->get_Picture()->set_Image(image);
    paragraphFormat->set_Indent(15);
    bulletFormat->set_Height(100);
    paragraph->set_Text(text);

    return paragraph;
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto sourceImage = Images::FromFile(u"image.png");
auto bulletImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

auto paragraph1 = createParagraph(u"The first paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = createParagraph(u"The second paragraph", bulletImage);
textFrame->get_Paragraphs()->Add(paragraph2);

presentation->Save(u"picture_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The picture bullets](picture_bullets.png)

## **Criar uma lista multinível**

Use [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/set_depth/) para posicionar itens de lista em diferentes níveis. O nível 0 é o nível superior, o nível 1 está aninhado abaixo dele e assim por diante.

O código C++ a seguir mostra como criar uma lista com marcadores multinível:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

auto textFrame = autoShape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->get_ParagraphFormat()->set_Depth(0);
paragraph1->set_Text(u"My text - Depth 0");
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->get_ParagraphFormat()->set_Depth(1);
paragraph2->set_Text(u"My text - Depth 1");
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph3 = System::MakeObject<Paragraph>();
paragraph3->get_ParagraphFormat()->set_Depth(2);
paragraph3->set_Text(u"My text - Depth 2");
textFrame->get_Paragraphs()->Add(paragraph3);

auto paragraph4 = System::MakeObject<Paragraph>();
paragraph4->get_ParagraphFormat()->set_Depth(3);
paragraph4->set_Text(u"My text - Depth 3");
textFrame->get_Paragraphs()->Add(paragraph4);

presentation->Save(u"multilevel_bullets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

O resultado:

![The multilevel list](multilevel_list.png)

## **Alterar uma lista existente**

Para alterar a formatação de lista em uma apresentação existente, acesse o parágrafo alvo e atualize suas configurações [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/get_bullet/). As mesmas propriedades usadas para criar listas podem ser usadas para inspecionar ou modificar listas carregadas de um arquivo PPT, PPTX ou ODP.

O código C++ a seguir altera o primeiro parágrafo em um quadro de texto para usar o estilo de lista numerada:

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto autoShape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraph(0);

auto paragraphFormat = paragraph->get_ParagraphFormat();
auto bulletFormat = paragraphFormat->get_Bullet();

bulletFormat->set_Type(BulletType::Numbered);
bulletFormat->set_NumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
bulletFormat->set_NumberedBulletStartWith(1);
paragraphFormat->set_MarginLeft(30);
paragraphFormat->set_Indent(-20);

presentation->Save(u"updated_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Perguntas frequentes**

**É possível exportar listas com marcadores e numeradas para PDF ou imagens?**

Sim. Aspose.Slides preserva a formatação da lista quando o formato de destino suporta o layout de texto e os recursos de marcador correspondentes.

**Posso editar listas em apresentações existentes?**

Sim. Carregue a apresentação, acesse o parágrafo alvo, inspecione ou atualize suas configurações [IParagraphFormat::get_Bullet](https://reference.aspose.com/slides/pt/cpp/aspose.slides/iparagraphformat/get_bullet/) e salve a apresentação.

**Listas podem conter texto não latino?**

Sim. O texto dos itens de lista pode conter caracteres Unicode, permitindo criar listas em apresentações multilíngues. Certifique‑se de que as fontes usadas na apresentação suportam os caracteres necessários.