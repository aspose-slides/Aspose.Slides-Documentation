---
title: Converter Apresentações PowerPoint para Documentos Word em C++
linktitle: PowerPoint para Word
type: docs
weight: 110
url: /pt/cpp/convert-powerpoint-to-word/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para Word
- apresentação para Word
- slide para Word
- PPT para Word
- PPTX para Word
- PowerPoint para DOCX
- apresentação para DOCX
- slide para DOCX
- PPT para DOCX
- PPTX para DOCX
- PowerPoint para DOC
- apresentação para DOC
- slide para DOC
- PPT para DOC
- PPTX para DOC
- salvar PPT como DOCX
- salvar PPTX como DOCX
- exportar PPT para DOCX
- exportar PPTX para DOCX
- C++
- Aspose.Slides
description: "Converter slides PowerPoint PPT e PPTX em documentos Word editáveis em C++ usando Aspose.Slides com layout preciso, imagens e formatação preservados."
---
## **Introdução**

Se você planeja usar conteúdo textual ou informações de uma apresentação (PPT ou PPTX) de novas maneiras, pode se beneficiar convertendo a apresentação para Word (DOC ou DOCX). 

* Em comparação ao Microsoft PowerPoint, o aplicativo Microsoft Word está mais equipado com ferramentas ou funcionalidades para conteúdo. 
* Além das funções de edição no Word, você também pode se beneficiar de recursos aprimorados de colaboração, impressão e compartilhamento. 

{{% alert color="primary" %}} 

Você pode querer experimentar nosso [**Conversor Online de Apresentação para Word**](https://products.aspose.app/slides/pt/conversion/ppt-to-word) para ver o que você pode ganhar ao trabalhar com conteúdo textual dos slides. 

{{% /alert %}} 

## **Aspose.Slides e Aspose.Words**

Para converter um arquivo PowerPoint (PPTX ou PPT) para Word (DOCX ou DOCX), você precisa de ambos [Aspose.Slides for C++](https://products.aspose.com/slides/pt/cpp/) e [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Como uma API independente, [Aspose.Slides](https://products.aspose.app/slides) para C++ fornece funções que permitem extrair textos de apresentações. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) é uma API avançada de processamento de documentos que permite que aplicativos gerem, modifiquem, convertam, renderizem, imprimam arquivos e realizem outras tarefas com documentos sem utilizar o Microsoft Word.

## **Converter uma Apresentação PowerPoint para um Documento Word**

Use este trecho de código para converter o PowerPoint para Word:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // gera e insere a imagem do slide
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // insere os textos do slide
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}
```

## **FAQ**

**Quais componentes precisam ser instalados para converter apresentações PowerPoint e OpenDocument em documentos Word?**

Você só precisa adicionar os pacotes correspondentes para [Aspose.Slides for C++](https://releases.aspose.com/slides/pt/cpp/) e [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) ao seu projeto. Ambas as bibliotecas funcionam como APIs independentes, e não há necessidade de ter o Microsoft Office instalado.

**Todos os formatos de apresentação PowerPoint e OpenDocument são suportados?**

Aspose.Slides [suporta todos os formatos de apresentação](/slides/pt/cpp/supported-file-formats/), incluindo PPT, PPTX, ODP e outros tipos de arquivo comuns. Isso garante que você possa trabalhar com apresentações criadas em várias versões do Microsoft PowerPoint.