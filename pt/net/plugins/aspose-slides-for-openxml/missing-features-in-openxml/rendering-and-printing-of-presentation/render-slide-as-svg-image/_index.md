---
title: Renderizar slide como imagem SVG
type: docs
weight: 50
url: /pt/net/render-slide-as-svg-image/
---
SVG—um acrônimo para Scalable Vector Graphics—é um tipo ou formato padrão de gráficos usado para renderizar imagens bidimensionais. O SVG armazena imagens como vetores em XML com detalhes que definem seu comportamento ou aparência.  

O SVG é um dos poucos formatos de imagens que atende a padrões muito elevados nesses aspectos: escalabilidade, interatividade, desempenho, acessibilidade, programabilidade e outros. Por essas razões, ele é comumente usado no desenvolvimento web.  

Você pode desejar usar arquivos SVG nesses cenários:

- quando você planeja imprimir sua apresentação em um formato muito grande. As imagens SVG podem ser escaladas para qualquer resolução ou nível. Você pode redimensionar as imagens SVG quantas vezes for necessário sem sacrificar a qualidade.  
- quando pretende usar gráficos e diagramas dos seus slides em diferentes meios ou plataformas. A maioria dos leitores pode interpretar arquivos SVG.  
- quando você precisa usar os menores tamanhos possíveis de imagens. Os arquivos SVG são geralmente menores que seus equivalentes de alta resolução em outros formatos, especialmente os formatos baseados em bitmap (JPEG ou PNG).  

Aspose.Slides for .NET permite exportar slides em suas apresentações como imagens **SVG**. Para gerar uma imagem SVG a partir de qualquer slide, faça o seguinte:

- Crie uma instância da classe Presentation.  
- Itere por todos os slides da apresentação.  
- Grave cada slide em seu próprio arquivo SVG usando FileStream.  

{{% alert color="primary" %}} 
Você pode querer experimentar nossa [aplicação web gratuita](https://products.aspose.app/slides/pt/conversion/ppt-to-svg) na qual implementamos a função de conversão de PPT para SVG do Aspose.Slides for .NET. 
{{% /alert %}} 

Este código de exemplo em C# mostra como converter PPT para SVG usando Aspose.Slides:  

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```