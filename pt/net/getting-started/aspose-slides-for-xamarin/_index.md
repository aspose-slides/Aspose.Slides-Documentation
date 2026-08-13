---
title: "Aspose.Slides para Xamarin"
type: docs
weight: 150
url: /pt/net/aspose-slides-for-xamarin/
keywords:
- Xamarin
- desenvolvimento móvel
- Android
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie aplicativos móveis Xamarin em C# para visualizar, editar e converter apresentações com Aspose.Slides, com suporte a recursos avançados para PPT, PPTX e ODP no Android."
---
## **Introdução**

Xamarin é um framework usado para desenvolvimento móvel em .NET C#. Xamarin possui ferramentas e bibliotecas que ampliam as capacidades da plataforma .NET. Ele permite que desenvolvedores criem aplicativos para o sistema operacional **Android**.

{{% alert color="info" %}} 

Para desenvolvimento em Xamarin, os programadores podem usar seus ambientes de desenvolvimento habituais (C#, Visual Studio e bibliotecas de terceiros).

{{% /alert %}}

A API Aspose.Slides funciona na plataforma Xamarin. Para isso, o pacote Aspose.Slides .NET adiciona uma DLL separada para Xamarin. Aspose.Slides for Xamarin suporta a maioria dos recursos disponíveis na versão .NET:

- conversão e visualização de apresentações.  
- edição de conteúdo em apresentações: texto, formas, gráficos, SmartArt, áudio/vídeo, fontes, etc.  
- manipulação de animação, efeitos 2D, WordArt, etc.  
- manipulação de metadados e propriedades de documento.  
- impressão, clonagem, mesclagem, comparação, divisão, etc.

Fornecemos uma comparação dos recursos completos em outra seção próxima ao final desta página.

Na API Aspose.Slides for Xamarin, as classes, namespaces, lógica e comportamento são tão semelhantes quanto possível à versão .NET. Você pode migrar suas aplicações Aspose.Slides .NET para Xamarin com custos mínimos.


## **Exemplo Rápido**
Você pode usar Aspose.Slides for Xamarin para criar e utilizar sua aplicação C# através do Slides for Android.

Estamos fornecendo um exemplo de aplicação Android via Xamarin que usa Aspose.Slides para exibir slides de apresentação e adiciona uma nova forma ao slide ao toque. Você pode encontrar o código‑fonte completo dos exemplos no [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Xamarin).

Vamos começar criando um Aplicativo Xamarin Android:

![todo:image_alt_text](https://lh3.googleusercontent.com/sNkKZnuuGo8phWI-4g4jRA_ZESKpO9RXehPj46RVymXGPcCJuYooePXcBEcb7N6uUUxgocl4o9OjwnajzWKmL2i4MUz3gKKwXw6C0ow_VScN8vlyGBK3SpLKoE_m9BDJ3iNE4xPj)

Primeiro, criamos um layout de conteúdo que conterá uma visualização de imagem, botões Anterior e Próximo:

![todo:image_alt_text](https://lh3.googleusercontent.com/rX9leIvYTVzQa0YAMj_jPUPs-c9_HwGPZUfR5A3FLiTk0-qzUQ29FfM4hammUVXbbw_Ly0LwEM_VnaI6vslEEMcVlEwVMem0LTiX5kYsA4lxtiHrvXfDPruWPOGU1YKDYSWcNM54)

**XML - content_main.xml - Criar layout de conteúdo**
``` 
 <LinearLayout
    xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:orientation=    "vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:showIn="@layout/activity_main">
    <LinearLayout
        android:orientation="horizontal"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:layout_weight="1"
        android:id="@+id/linearLayout1">
        <ImageView
            android:src="@android:drawable/ic_menu_gallery"
            android:layout_width="match_parent"
            android:layout_height="match_parent"
            android:id="@+id/imageView"
            android:scaleType="fitCenter" />
    </LinearLayout>

    <LinearLayout
        android:orientation="horizontal"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:layout_weight="10"
        android:id="@+id/linearLayout2">
        <Button
            android:text="Prev"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonPrev" />
        <Button
            android:text="Next"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:id="@+id/buttonNext"/>
    </LinearLayout>
</LinearLayout>
```

Aqui, referenciamos a biblioteca "Aspose.Slides.Droid.dll" que inclui uma apresentação de exemplo ("HelloWorld.pptx") nos Assets da aplicação Xamarin e adicionamos sua inicialização ao MainActivity:

**C# - MainActivity.cs - Inicialização**

``` csharp
using System.Diagnostics;
using Aspose.Slides.Theme;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    private Aspose.Slides.Presentation presentation;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);
    }

    protected override void OnResume()
    {
        if (presentation == null)
        {
            using (Stream input = Assets.Open("HelloWorld.pptx"))
            {
                presentation = new Aspose.Slides.Presentation(input);
            }
        }
    }

    protected override void OnPause()
    {
        if (presentation != null)
        {
            presentation.Dispose();
            presentation = null;
        }
    }
}
```

Vamos adicionar a função para exibir os slides Anterior e Próximo ao tocar nos botões:

**C# - MainActivity.cs - Exibir slides ao clicar nos botões Anterior e Próximo**

``` csharp
using System.Diagnostics;
using Aspose.Slides.Theme;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
public class MainActivity : AppCompatActivity
{
    private Button buttonNext;
    private Button buttonPrev;
    ImageView imageView;

    private Aspose.Slides.Presentation presentation;

    private int currentSlideNumber;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);
    }

    protected override void OnResume()
    {
        base.OnResume();
        LoadPresentation();
        currentSlideNumber = 0;
        if (buttonNext == null)
        {
            buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
        }

        if (buttonPrev == null)
        {
            buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
        }

        if(imageView == null)
        {
            imageView= FindViewById<ImageView>(Resource.Id.imageView);
        }

        buttonNext.Click += ButtonNext_Click;
        buttonPrev.Click += ButtonPrev_Click;
        RefreshButtonsStatus();
        ShowSlide(currentSlideNumber);
    }

    private void ButtonNext_Click(object sender, System.EventArgs e)
    {
        if (currentSlideNumber > (presentation.Slides.Count - 1))
        {
            return;
        }

        ShowSlide(++currentSlideNumber);
        RefreshButtonsStatus();
    }

    private void ButtonPrev_Click(object sender, System.EventArgs e)
    {
        if (currentSlideNumber == 0)
        {
            return;
        }

        ShowSlide(--currentSlideNumber);
        RefreshButtonsStatus();
    }

    protected override void OnPause()
    {
        base.OnPause();
        if (buttonNext != null)
        {
            buttonNext.Dispose();
            buttonNext = null;
        }

        if (buttonPrev != null)
        {
            buttonPrev.Dispose();
            buttonPrev = null;
        }

        if(imageView != null)
        {
            imageView.Dispose();
            imageView = null;
        }

        DisposePresentation();
    }

    private void RefreshButtonsStatus()
    {
        buttonNext.Enabled = currentSlideNumber < (presentation.Slides.Count - 1);
        buttonPrev.Enabled = currentSlideNumber > 0;
    }

    private void ShowSlide(int slideNumber)
    {
        Aspose.Slides.Drawing.Xamarin.Size size = presentation.SlideSize.Size.ToSize();
        Aspose.Slides.Drawing.Xamarin.Bitmap bitmap = presentation.Slides[slideNumber].GetThumbnail(size);
        imageView.SetImageBitmap(bitmap.ToNativeBitmap());
    }

    private void LoadPresentation()
    {
        if(presentation != null)
        {
            return;
        }

        using (Stream input = Assets.Open("HelloWorld.pptx"))
        {
            presentation = new Aspose.Slides.Presentation(input);
        }
    }

    private void DisposePresentation()
    {
        if(presentation == null)
        {
            return;
        }
        
        presentation.Dispose();
        presentation = null;
    }

}
```

Por fim, vamos implementar uma função para adicionar uma forma elíptica ao tocar no slide:

**C# - MainActivity.cs - Adicionar elipse ao clicar no slide**

``` csharp
 private void ImageView_Touch(object sender, Android.Views.View.TouchEventArgs e)
{
    int[] location = new int[2];
    imageView.GetLocationOnScreen(location);
    int x = (int)e.Event.GetX();
    int y = (int)e.Event.GetY();
    int posX = x - location[0];
    int posY = y - location[0];
    
    Aspose.Slides.Drawing.Xamarin.Size presSize = presentation.SlideSize.Size.ToSize();

    float coeffX = (float)presSize.Width / imageView.Width;
    float coeffY = (float)presSize.Height / imageView.Height;
    int presPosX = (int)(posX * coeffX);
    int presPosY = (int)(posY * coeffY);
    int width = presSize.Width / 50;

    int height = width;
    Aspose.Slides.IAutoShape ellipse = presentation.Slides[currentSlideNumber].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, presPosX, presPosY, width, height);
    ellipse.FillFormat.FillType = Aspose.Slides.FillType.Solid;

    Random random = new Random();
    Aspose.Slides.Drawing.Xamarin.Color slidesColor = Aspose.Slides.Drawing.Xamarin.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
    ellipse.FillFormat.SolidFillColor.Color = slidesColor;
    ShowSlide(currentSlideNumber);
}
```

Cada clique no slide da apresentação adiciona uma elipse de cor aleatória:

![todo:image_alt_text](https://lh4.googleusercontent.com/RhjFHm6SgzOkXaehKhsY8q7SRZLFC7vV8_jyw-Gy4Scy68wTMg_apLZ3vPzRLOt1eEw_zUZmLlVhJ8oTGCg10dRNAETLSClRTBEyj2MWuefNpJI4i7WLIe0x8A7xuh4CV91loLKi)


## **Recursos Suportados**

|**RECURSOS**|**Aspose.Slides for .NET**|**Aspose.Slides for Xamarin**|
| :- | :- | :- |
|**Recursos de apresentação:**| | |
|Criar novas apresentações|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formatos PowerPoint 97 - 2003 abrir/salvar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formatos PowerPoint 2007 abrir/salvar|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Suporte a extensões PowerPoint 2010|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Suporte a extensões PowerPoint 2013|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Suporte a recursos PowerPoint 2016|restricted|restricted|
|Suporte a recursos PowerPoint 2019|restricted|restricted|
|Conversão PPT para PPTX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Conversão PPTX para PPT|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|PPTX em PPT|restricted|restricted|
|Processamento de temas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Processamento de macros|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Processamento de propriedades de documentos|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Proteção por senha|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Extração rápida de texto|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Incorporação de fontes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Renderização de comentários|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Interrupção de tarefas de longa duração|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formatos de exportação:**| | |
|PDF|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|XPS|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|HTML|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|TIFF|{{< emoticons/tick >}}|{{< emoticons/cross >}}|
|ODP|restricted|restricted|
|SWF|restricted|restricted|
|SVG|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Formatos de importação:**| | |
|HTML|restricted|restricted|
|ODP|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|THMX|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Recursos de slides mestre:**| | |
|Acessar todos os slides mestres existentes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Criar/remover slides mestres|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar slides mestres|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Recursos de slides de layout:**| | |
|Acessar todos os slides de layout existentes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Criar/remover slides de layout|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar slides de layout|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Recursos de slides:**| | |
|Acessar todos os slides existentes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Criar/remover slides|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar slides|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportar slides para imagens|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Criar/editar/remover seções de slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Recursos de slides de notas:**| | |
|Acessar todos os slides de notas existentes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Recursos de formas:**| | |
|Acessar todas as formas de slide|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Adicionar novas formas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Clonar formas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Exportar formas individuais para imagens|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Tipos de formas suportados:**| | |
|Todos os tipos de formas predefinidas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Molduras de imagem|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Tabelas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Gráficos|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|SmartArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Diagrama legado|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|WordArt|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Objetos OLE, ActiveX|restricted|restricted|
|Molduras de vídeo|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Molduras de áudio|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Conectores|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Recursos de formas agrupadas:**| | |
|Acessar formas agrupadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Criar formas agrupadas|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Desagrupar formas agrupadas existentes|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Recursos de efeitos de formas:**| | |
|Efeitos 2D|restricted|restricted|
|Efeitos 3D|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|**Recursos de texto:**| | |
|Formatação de parágrafos|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|Formatação de porções|{{< emoticons/tick >}}|{{< emoticons/tick >}}|
|**Recursos de animação:**| | |
|Exportar animação para SWF|{{< emoticons/cross >}}|{{< emoticons/cross >}}|
|Exportar animação para HTML|{{< emoticons/cross >}}|{{< emoticons/cross >}}|