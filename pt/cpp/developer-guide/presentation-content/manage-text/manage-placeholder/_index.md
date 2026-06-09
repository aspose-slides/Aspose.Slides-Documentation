---
title: Gerenciar Marcadores de Posição de Apresentação em C++
linktitle: Gerenciar Marcadores de Posição
type: docs
weight: 10
url: /pt/cpp/manage-placeholder/
keywords:
- marcador de posição
- marcador de posição de texto
- marcador de posição de imagem
- marcador de posição de gráfico
- texto de sugestão
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Gerencie marcadores de posição no Aspose.Slides para C++ de forma simples: substitua texto, personalize sugestões e defina transparência de imagem no PowerPowerPoint e OpenDocument."
---
## **Visão geral**

Aspose.Slides permite que você gerencie marcadores de posição de apresentações programaticamente. Este artigo explica como encontrar marcadores de posição nos slides e alterar seu texto, definir texto de sugestão personalizado para layouts de marcadores de posição e ajustar a transparência de uma imagem usada como plano de fundo de um marcador de posição. Também inclui um breve FAQ que esclarece a diferença entre marcadores de posição base e formas locais, explica como as alterações de marcadores de posição podem ser aplicadas por meio de layouts ou mestres, e aponta para o gerenciamento de marcadores de posição de cabeçalho e rodapé.

## **Alterar texto em um marcador de posição**
Usando [Aspose.Slides for C++](/slides/pt/cpp/), você pode encontrar e modificar marcadores de posição nos slides de apresentações. Aspose.Slides permite que você faça alterações no texto de um marcador de posição.

**Pré-requisito**: Você precisa de uma apresentação que contenha um marcador de posição. Você pode criar essa apresentação no aplicativo Microsoft PowerPoint padrão.

É assim que você usa Aspose.Slides para substituir o texto no marcador de posição nessa apresentação:

1. Instancie a classe [`Presentation`](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation/) e passe a apresentação como argumento.
2. Obtenha uma referência ao slide através de seu índice.
3. Itere pelas formas para encontrar o marcador de posição.
4. Converta a forma do marcador de posição para um [`AutoShape`](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.auto_shape/) e altere o texto usando o [`TextFrame`](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.text_frame/) associado ao [`AutoShape`](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.auto_shape/).
5. Salve a apresentação modificada.

Este código C++ mostra como alterar o texto em um marcador de posição:

```c++
// O caminho para o diretório de documentos.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Carrega a apresentação desejada
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Acessa o primeiro slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Acessa o primeiro e segundo marcador de posição no slide e faz cast para AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Salva a apresentação no disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Definir texto de sugestão em um marcador de posição**
Os layouts padrão e pré-construídos contêm textos de sugestão de marcador de posição, como ***Click to add a title*** ou ***Click to add a subtitle***. Usando Aspose.Slides, você pode inserir seus próprios textos de sugestão nos layouts de marcadores de posição.

Este código C++ mostra como definir o texto de sugestão em um marcador de posição:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Quando não há texto nele, o PowerPoint exibe "Clique para adicionar título". 
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Faz a mesma coisa para subtítulo.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Definir transparência da imagem do marcador de posição**

Aspose.Slides permite definir a transparência da imagem de fundo em um marcador de posição de texto. Ajustando a transparência da imagem nesse quadro, você pode fazer com que o texto ou a imagem se destaquem (dependendo das cores do texto e da imagem).

Este código C++ mostra como definir a transparência para o fundo da imagem (dentro de uma forma):

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **FAQ**

**O que é um marcador de posição base e como ele difere de uma forma local em um slide?**

Um marcador de posição base é a forma original em um layout ou mestre da qual a forma do slide herda—tipo, posição e algumas formatações provêm dele. Uma forma local é independente; se não houver um marcador de posição base, a herança não se aplica.

**Como posso atualizar todos os títulos ou legendas em toda a apresentação sem iterar sobre cada slide?**

Edite o marcador de posição correspondente no layout ou no mestre. Slides baseados nesses layouts/nesse mestre herdarão a alteração automaticamente.

**Como controlo os marcadores de posição padrão de cabeçalho/rodapé — data e hora, número do slide e texto do rodapé?**

Use os gerenciadores HeaderFooter no escopo apropriado (slides normais, layouts, mestre, notas/folhetos) para ativar ou desativar esses marcadores de posição e definir seu conteúdo.