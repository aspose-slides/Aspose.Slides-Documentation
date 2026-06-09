---
title: Renderizando Formas no Slide como Imagens
type: docs
weight: 120
url: /pt/net/rendering-shapes-on-slide-as-images/
---
Isso cobre duas funções principais:

- Extraindo Imagem de forma para arquivo.
- Extraindo Formas como arquivo de imagem.
## **Extrair uma Imagem de uma Forma para um Arquivo**
As imagens são adicionadas no fundo do slide e nas formas. Às vezes, é necessário extrair as imagens adicionadas nas formas da apresentação.

No **Aspose.Slides for .NET**, as imagens podem ser adicionadas à forma do slide e ao fundo do slide. As imagens são adicionadas em **ImageCollectionEx** da apresentação. Neste exemplo, percorreremos cada forma dentro de cada slide da apresentação e verificaremos se há alguma imagem adicionada na forma do slide. Se a imagem for encontrada em alguma forma, extrairemos e a salvaremos em um arquivo. O trecho de código a seguir atenderá ao objetivo.

``` csharp

 //Acessando a apresentação

PresentationEx pres = new PresentationEx("RenderImageFromShape.pptx");

ImageEx img = null;

int slideIndex = 0;

String ImageType = "";

bool ifImageFound = false;

for (int i = 0; i < pres.Slides.Count; i++)

{

	slideIndex++;

	//Acessando o primeiro slide

	SlideEx sl = pres.Slides[i];

	System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

	for (int j = 0; j < sl.Shapes.Count; j++)

	{

		// Acessando a forma com imagem

		ShapeEx sh = sl.Shapes[j];

		if (sh is AutoShapeEx)

		{

			AutoShapeEx ashp = (AutoShapeEx)sh;

			if (ashp.FillFormat.FillType == FillTypeEx.Picture)

			{

				img = ashp.FillFormat.PictureFillFormat.Picture.Image;

				ImageType = img.ContentType;

				ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);

				ifImageFound = true;

			}

		}

		else if (sh is PictureFrameEx)

		{

			PictureFrameEx pf = (PictureFrameEx)sh;

			if (pf.FillFormat.FillType == FillTypeEx.Picture)

			{

				img = pf.PictureFormat.Picture.Image;

				ImageType = img.ContentType;

				ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);

				ifImageFound = true;

			}

		}


		//

		//Definindo o formato de imagem desejado

		if (ifImageFound)

		{

			switch (ImageType)

			{

				case "jpeg":

					Format = System.Drawing.Imaging.ImageFormat.Jpeg;

					break;

				case "emf":

					Format = System.Drawing.Imaging.ImageFormat.Emf;

					break;

				case "bmp":

					Format = System.Drawing.Imaging.ImageFormat.Bmp;

					break;

				case "png":

					Format = System.Drawing.Imaging.ImageFormat.Png;

					break;

				case "wmf":

					Format = System.Drawing.Imaging.ImageFormat.Wmf;

					break;

				case "gif":

					Format = System.Drawing.Imaging.ImageFormat.Gif;

					break;

			}

			//

			img.Image.Save(path+"ResultedImage"+"." + ImageType, Format);

		}

		ifImageFound = false;

``` 
## **Baixar Código de Exemplo**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Shapes%20and%20Slide%20to%20Images%20%28Aspose.Slides%29.zip)
## **Extrair Formas como Arquivos de Imagem**
```cs
//Instancia o objeto Presentation que representa um arquivo PPT
Presentation pres = new Presentation("RenderShapeAsImage.ppt");

//Acessando um slide usando sua posição
ISlide slide = pres.Slides[2];

for (int i = 0; i < slide.Shapes.Count; i++)
{
    IShape shape = slide.Shapes[i];

    //Obtendo a imagem miniatura da forma
    using (IImage image = shape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f))
    {
        //Salvando a imagem miniatura no formato gif
        image.Save(i + ".gif", ImageFormat.Gif);
    }
}
```

*Nota:* A extração de forma é atualmente suportada em arquivos .ppt.
## **Baixar Código de Exemplo**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Rendering%20Individual%20Shapes%20as%20Images%20%28Aspose.Slides%29.zip)