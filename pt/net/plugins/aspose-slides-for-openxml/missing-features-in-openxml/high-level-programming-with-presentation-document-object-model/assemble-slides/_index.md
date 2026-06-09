---
title: Montar Slides
type: docs
weight: 10
url: /pt/net/assemble-slides/
---
## **Adicionar um Slide a uma Apresentação**
Antes de falar sobre a adição de slides aos arquivos de apresentação, vamos discutir alguns fatos sobre os slides. Cada arquivo de apresentação do PowerPoint contém slide Mestre / Layout e outros slides Normais. Isso significa que um arquivo de apresentação contém ao menos um slide. É importante saber que arquivos de apresentação sem slides não são suportados pelo Aspose.Slides for .NET. Cada slide tem um Id exclusivo e todos os Slides Normais são organizados em uma ordem especificada pelo índice baseado em zero.

O Aspose.Slides for .NET permite que os desenvolvedores adicionem slides vazios à sua apresentação. Para adicionar um slide vazio na apresentação, siga os passos abaixo:

- Crie uma instância da classe **Presentation**
- Instancie a classe **SlideCollection** definindo uma referência à propriedade Slides (coleção de objetos Slide) exposta pelo objeto Presentation
- Adicione um slide vazio à apresentação ao final da coleção de slides de conteúdo chamando o método **AddEmptySlide** exposto pelo objeto **SlideCollection**
- Execute alguma operação com o slide vazio recém‑adicionado
- Por fim, grave o arquivo de apresentação usando o objeto **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx;

//Instanciar a classe SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Adicionar um slide vazio à coleção Slides

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Salvar o arquivo PPTX no disco

pres.Write("EmptySlide.pptx");

``` 
## **Acessar Slides de uma Apresentação**
O Aspose.Slides for .NET fornece a classe Presentation que pode ser usada para encontrar e acessar qualquer slide desejado presente na apresentação.

**Usando a Coleção de Slides**

A classe **Presentation** representa um arquivo de apresentação e expõe todos os slides nele como uma coleção **SlideCollection** (que é uma coleção de objetos **Slide**). Todos esses slides podem ser acessados a partir desta coleção **Slides** usando um índice de slide.

``` csharp

 //Instanciar um objeto Presentation que representa um arquivo de apresentação

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Acessando um slide usando seu índice de slide

SlideEx slide = pres.Slides[0];

``` 
## **Remover Slides**
Sabemos que a classe Presentation em **Aspose.Slides for .NET** representa um arquivo de apresentação. A classe Presentation encapsula uma **SlideCollection** que atua como repositório de todos os slides que fazem parte da apresentação. Os desenvolvedores podem remover um slide desta coleção de Slides de duas maneiras:

- Usando Referência de Slide
- Usando Índice de Slide

**Usando Referência de Slide**

Para remover um slide usando sua referência, siga os passos abaixo:

- Crie uma instância da classe Presentation
- Obtenha a referência de um slide usando seu Id ou Índice
- Remova o slide referenciado da apresentação
- Grave o arquivo de apresentação modificado

``` csharp

 //Instanciar um objeto Presentation que representa um arquivo de apresentação

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Acessando um slide usando seu índice na coleção de slides

SlideEx slide = pres.Slides[0];

//Removendo um slide usando sua referência

pres.Slides.Remove(slide);

//Gravando o arquivo de apresentação

pres.Write("modified.pptx");

``` 
## **Alterar a Posição de um Slide**
É muito simples mudar a posição de um slide na apresentação. Basta seguir os passos abaixo:

- Crie uma instância da classe Presentation
- Obtenha a referência de um slide usando seu Índice
- Altere o SlideNumber do slide referenciado
- Grave o arquivo de apresentação modificado

No exemplo abaixo, alteramos a posição de um slide (situado na posição de índice zero 1) da apresentação para o índice 1 (Posição 2).

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//Instanciar a classe SlideCollection

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Adicionar um slide vazio à coleção Slides

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Salvar o arquivo PPTX no disco

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instanciar um objeto Presentation que representa um arquivo de apresentação

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Acessando um slide usando seu índice de slide

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instanciar um objeto Presentation que representa um arquivo de apresentação

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Acessando um slide usando seu índice na coleção de slides

ISlide slide = pres.Slides[0];

//Removendo um slide usando sua referência

pres.Slides.Remove(slide);

//Gravando o arquivo de apresentação

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instanciar a classe Presentation para carregar o arquivo de apresentação fonte

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Obter o slide cuja posição será alterada

    ISlide sld = pres.Slides[0];

    //Definir a nova posição para o slide

    sld.SlideNumber = 2;

    //Gravar a apresentação no disco

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Baixar Código de Exemplo**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)