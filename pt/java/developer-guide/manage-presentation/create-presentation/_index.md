---
title: Criar apresentações em Java
linktitle: Criar apresentação
type: docs
weight: 10
url: /pt/java/create-presentation/
keywords:
- criar apresentação
- nova apresentação
- criar PPT
- novo PPT
- criar PPTX
- novo PPTX
- criar ODP
- novo ODP
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Crie apresentações em Java com Aspose.Slides — produza arquivos PPT, PPTX e ODP, aproveite o suporte a OpenDocument e salve-os programaticamente para resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação no Aspose.Slides, adicionar conteúdo simples a um slide e salvar o resultado como um arquivo. Também demonstra como criar e salvar uma nova apresentação, abrir uma apresentação existente em um formato suportado e salvá‑la em outro formato. Além disso, o artigo inclui uma breve FAQ que cobre perguntas comuns relacionadas a formatos, modelos, dimensionamento de slides, unidades, uso de memória, multithreading, licenciamento, assinaturas digitais e suporte a VBA.

## **Criar uma apresentação**

Criar um arquivo PowerPoint do zero no Aspose.Slides for Java é tão simples quanto instanciar a classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/). O construtor fornece automaticamente um deck em branco com um único slide, oferecendo uma tela imediata para formas, texto, gráficos ou qualquer outro conteúdo que sua aplicação precise. Depois de modificar esse slide — ou adicionar novos — você pode armazenar o resultado em PPTX, PPT legados ou até mesmo em formatos OpenDocument. O breve exemplo de código abaixo ilustra esse fluxo adicionando uma forma simples ao primeiro slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/).
2. Obtenha uma referência ao slide pelo seu índice.
3. Adicione um objeto [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) do tipo `Cloud` usando o método `addAutoShape` exposto pela coleção `Shapes`.
4. Adicione texto ao auto-shape.
5. Salve a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, uma forma de nuvem é adicionada ao primeiro slide da apresentação.

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obtenha o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicione uma autoforma do tipo Nuvem.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // Salve a apresentação como um arquivo PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The new presentation](new_presentation.png)

## **Perguntas frequentes**

**Em quais formatos posso salvar uma nova apresentação?**

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/java/save-presentation/), e exportar para [PDF](/slides/pt/java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/java/convert-powerpoint-to-xps/), [HTML](/slides/pt/java/convert-powerpoint-to-html/), [SVG](/slides/pt/java/convert-powerpoint-to-png/) e [imagens](/slides/pt/java/convert-powerpoint-to-png/), entre outros.

**Posso iniciar a partir de um modelo (POTX/POTM) e salvar como um PPTX padrão?**

Sim. Carregue o modelo e salve no formato desejado; os formatos POTX/POTM/PPTM e semelhantes [são suportados](/slides/pt/java/supported-file-formats/).

**Como controlo o tamanho ou a proporção do slide ao criar uma apresentação?**

Defina o [tamanho do slide](/slides/pt/java/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

**Em que unidades são medidos tamanho e coordenadas?**

Em pontos: 1 polegada equivale a 72 unidades.

**Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?**

Use [estratégias de gerenciamento de BLOB](/slides/pt/java/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos de trabalho baseados em arquivos em vez de streams puramente em memória.

**Posso criar/salvar apresentações em paralelo?**

Não é possível operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) a partir de [várias threads](/slides/pt/java/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

**Como removo a marca d'água de avaliação e as limitações?**

[Aplique uma licença](/slides/pt/java/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado, e a configuração da licença deve ser sincronizada se várias threads estiverem envolvidas.

**Posso assinar digitalmente o PPTX que crio?**

Sim. [Assinaturas digitais](/slides/pt/java/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

**Macros (VBA) são suportadas em apresentações criadas?**

Sim. Você pode [criar/editar projetos VBA](/slides/pt/java/presentation-via-vba/) e salvar arquivos habilitados para macro, como PPTM/PPSM.