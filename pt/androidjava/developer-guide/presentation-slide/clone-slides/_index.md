---
title: Clonar Slides de Apresentação no Android
linktitle: Clonar Slides
type: docs
weight: 35
url: /pt/androidjava/clone-slides/
keywords:
- clonar slide
- copiar slide
- salvar slide
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Duplique slides de PowerPoint com Aspose.Slides para Android. Siga nossos exemplos claros de código Java para automatizar a criação de PPT em segundos e eliminar o trabalho manual."
---
## **Introdução**

Clonar é o processo de fazer uma cópia exata ou réplica de algo. Aspose.Slides for Android via Java também possibilita criar uma cópia ou clone de qualquer slide e, em seguida, inserir esse slide clonado na apresentação atual ou em qualquer outra apresentação aberta. O processo de clonagem de slides cria um novo slide que pode ser modificado por desenvolvedores sem alterar o slide original. Existem várias maneiras possíveis de clonar um slide:

- Clonar ao final dentro de uma apresentação.
- Clonar em outra posição dentro da apresentação.
- Clonar ao final em outra apresentação.
- Clonar em outra posição em outra apresentação.
- Clonar em uma posição específica em outra apresentação.

No Aspose.Slides for Android via Java, (uma coleção de [ISlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlide) objetos) exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) fornece os métodos [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) e [insertClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) para executar os tipos de clonagem de slide descritos acima.

## **Clonar um Slide ao Final de uma Apresentação**
Se você quiser clonar um slide e, em seguida, usá‑lo dentro do mesmo arquivo de apresentação ao final dos slides existentes, use o método [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) conforme os passos listados abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getSlides--) referenciando a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getSlides--) e passe o slide a ser clonado como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Grave o arquivo de apresentação modificado.

No exemplo abaixo, clonamos um slide (situado na primeira posição – índice zero – da apresentação) para o final da apresentação.

```java
// Instanciar a classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clonar o slide desejado para o final da coleção de slides na mesma apresentação
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Gravar a apresentação modificada no disco
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonar um Slide para Outra Posição dentro de uma Apresentação**
Se você quiser clonar um slide e, em seguida, usá‑lo dentro do mesmo arquivo de apresentação, mas em uma posição diferente, use o método [insertClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
1. Instancie a classe referenciando a coleção **[Slides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getSlides--)** exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).
1. Chame o método [insertClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getSlides--) e passe o slide a ser clonado junto com o índice para a nova posição como parâmetro para o método [insertClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, clonamos um slide (situado no índice zero – posição 1 – da apresentação) para o índice 1 – Posição 2 – da apresentação.

```java
// Instanciar a classe Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clonar o slide desejado para o final da coleção de slides na mesma apresentação
    ISlideCollection slds = pres.getSlides();

    // Clonar o slide desejado para o índice especificado na mesma apresentação
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Gravar a apresentação modificada no disco
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Clonar um Slide ao Final de outra Apresentação**
Se precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, ao final dos slides existentes:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que contém a apresentação de origem do slide.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que contém a apresentação de destino à qual o slide será adicionado.
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection) referenciando a coleção **[Slides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getSlides--)** exposta pelo objeto Presentation da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getSlides--) e passe o slide da apresentação de origem como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide (do primeiro índice da apresentação de origem) para o final da apresentação de destino.

```java
// Instanciar a classe Presentation para carregar o arquivo de apresentação de origem
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanciar a classe Presentation para o PPTX de destino (onde o slide será clonado)
    Presentation destPres = new Presentation();
    try {
        // Clonar o slide desejado da apresentação de origem para o final da coleção de slides na apresentação de destino
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Gravar a apresentação de destino no disco
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar um Slide para Outra Posição em outra Apresentação**
Se precisar clonar um slide de uma apresentação e usá‑lo em outra apresentação, em uma posição específica:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que contém a apresentação de origem do slide.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que contém a apresentação à qual o slide será adicionado.
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getSlides--) referenciando a coleção Slides exposta pelo objeto Presentation da apresentação de destino.
1. Chame o método [insertClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getSlides--) e passe o slide da apresentação de origem juntamente com a posição desejada como parâmetro para o método [insertClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide (do índice zero da apresentação de origem) para o índice 1 (posição 2) da apresentação de destino.

```java
// Instanciar a classe Presentation para carregar o arquivo de apresentação de origem
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instanciar a classe Presentation para o PPTX de destino (onde o slide será clonado)
    Presentation destPres = new Presentation();
    try {
        // Clonar o slide desejado da apresentação de origem para o final da coleção de slides na apresentação de destino
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Gravar a apresentação de destino no disco
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Clonar um Slide em uma Posição Específica em outra Apresentação**
Se precisar clonar um slide com um slide mestre de uma apresentação e usá‑lo em outra apresentação, primeiro clone o slide mestre desejado da apresentação de origem para a de destino. Em seguida, use esse slide mestre para clonar o slide com mestre. O método [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) espera um slide mestre da apresentação de destino, não da de origem. Para clonar o slide com mestre, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que contém a apresentação de origem do slide.
1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que contém a apresentação de destino para a qual o slide será clonado.
1. Acesse o slide a ser clonado juntamente com o slide mestre.
1. Instancie a classe [IMasterSlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IMasterSlideCollection) referenciando a coleção Masters exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposto pelo objeto [IMasterSlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IMasterSlideCollection) e passe o mestre da apresentação PPTX de origem a ser clonado como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Instancie a classe [ISlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getSlides--) configurando a referência para a coleção Slides exposta pelo objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) da apresentação de destino.
1. Chame o método [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) exposto pelo objeto [ISlideCollection](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation#getSlides--) e passe o slide da apresentação de origem a ser clonado e o slide mestre como parâmetro para o método [addClone](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. Grave o arquivo da apresentação de destino modificada.

No exemplo abaixo, clonamos um slide com mestre (situado no índice zero da apresentação de origem) para o final da apresentação de destino usando o mestre do slide de origem.

```java
    // Instanciar a classe Presentation para carregar o arquivo de apresentação de origem
    Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
    try {
        // Instanciar a classe Presentation para a apresentação de destino (onde o slide será clonado)
        Presentation destPres = new Presentation();
        try {
            // Instanciar ISlide a partir da coleção de slides na apresentação de origem juntamente com
            // slide mestre
            ISlide SourceSlide = srcPres.getSlides().get_Item(0);
            IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

            // Clonar o slide mestre desejado da apresentação de origem para a coleção de mestres na
            // apresentação de destino
            IMasterSlideCollection masters = destPres.getMasters();
            IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

            // Clonar o slide mestre desejado da apresentação de origem para a coleção de mestres na
            // apresentação de destino
            IMasterSlide iSlide = masters.addClone(SourceMaster);

            // Clonar o slide desejado da apresentação de origem com o mestre desejado para o final da
            // coleção de slides na apresentação de destino
            ISlideCollection slds = destPres.getSlides();
            slds.addClone(SourceSlide, iSlide, true);

            // Salvar a apresentação de destino no disco
            destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
        } finally {
            destPres.dispose();
        }
    } finally {
        srcPres.dispose();
    }
```

## **Clonar um Slide ao Final de uma Seção Especificada**
Se você quiser clonar um slide e, em seguida, usá‑lo dentro do mesmo arquivo de apresentação, mas em uma seção diferente, use o método [**addClone**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) exposto pela interface [**ISlideCollection**](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides for Android via Java permite clonar um slide da primeira seção e, em seguida, inserir esse slide clonado na segunda seção da mesma apresentação.

O trecho de código a seguir mostra como clonar um slide e inserir o slide clonado em uma seção especificada.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Salvar a apresentação de destino no disco
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**As notas do apresentador e os comentários de revisão são clonados?**

Sim. A página de notas e os comentários de revisão são incluídos na cópia. Se não quiser mantê‑los, [remova‑os](/slides/pt/androidjava/presentation-notes/) após a inserção.

**Como gráficos e suas fontes de dados são tratados?**

O objeto de gráfico, formatação e dados incorporados são copiados. Se o gráfico estava vinculado a uma fonte externa (por exemplo, uma planilha incorporada via OLE), esse vínculo é preservado como um [objeto OLE](/slides/pt/androidjava/manage-ole/). Após mover entre arquivos, verifique a disponibilidade dos dados e o comportamento de atualização.

**Posso controlar a posição de inserção e as seções do clone?**

Sim. Você pode inserir o clone em um índice de slide específico e colocá‑lo em uma [seção](/slides/pt/androidjava/slide-section/) escolhida. Se a seção de destino não existir, crie‑a primeiro e então mova o slide para ela.