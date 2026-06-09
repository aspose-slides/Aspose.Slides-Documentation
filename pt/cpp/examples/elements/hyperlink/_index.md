---
title: Hyperlink
type: docs
weight: 130
url: /pt/cpp/examples/elements/hyperlink/
keywords:
- exemplo de código
- hyperlink
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Adicione e gerencie hyperlinks no Aspose.Slides for C++: texto de link, formas e imagens, defina destinos e ações para PPT, PPTX e ODP com exemplos em C++."
---
Este artigo demonstra como adicionar, acessar, remover e atualizar hyperlinks em formas usando **Aspose.Slides for C++**.

## **Adicionar um Hyperlink**
Crie uma forma retangular com um hyperlink apontando para um site externo.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **Acessar um Hyperlink**
Leia as informações do hyperlink a partir da parte de texto de uma forma.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **Remover um Hyperlink**
Remova o hyperlink do texto de uma forma.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **Atualizar um Hyperlink**
Altere o destino de um hyperlink existente. Use `HyperlinkManager` para modificar o texto que já contém um hyperlink, o que imita como o PowerPoint atualiza hyperlinks com segurança.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // Alterar um hyperlink dentro de um texto existente deve ser feito via
    // HyperlinkManager em vez de definir a propriedade diretamente.
    // Isso imita como o PowerPoint atualiza hyperlinks de forma segura.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```