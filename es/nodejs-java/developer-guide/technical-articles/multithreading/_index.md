---
title: Multihilos en Aspose.Slides
type: docs
weight: 310
url: /es/nodejs-java/multithreading/
keywords:
- PowerPoint
- presentación
- multihilos
- trabajo paralelo
- convertir diapositivas
- diapositivas a imágenes
- JavaScript
- Aspose.Slides para Node.js vía Java
---

## **Introducción**

Aunque el trabajo paralelo con presentaciones es posible (además del análisis/carga/duplicado) y todo funciona bien (la mayoría de las veces), existe una pequeña probabilidad de obtener resultados incorrectos al usar la biblioteca en varios hilos.

Recomendamos encarecidamente que **no** utilice una única instancia de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) en un entorno de multihilos porque podría producir errores o fallos impredecibles que no se detectan fácilmente.

No es **seguro** cargar, guardar y/o duplicar una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) en varios hilos. Estas operaciones **no** están soportadas.  Si necesita realizar esas tareas, debe paralelizar las operaciones usando varios procesos monohilo, y cada uno de esos procesos debe usar su propia instancia de presentación.

## **Convertir diapositivas de una presentación a imágenes en paralelo**

Supongamos que queremos convertir todas las diapositivas de una presentación de PowerPoint a imágenes PNG en paralelo. Como no es seguro usar una única instancia de `Presentation` en varios hilos, dividimos las diapositivas en presentaciones separadas y convertimos las diapositivas a imágenes en paralelo, usando cada presentación en un hilo distinto. El siguiente ejemplo de código muestra cómo hacerlo.
```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Extraer la diapositiva i en una presentación separada.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Esperar a que todas las tareas se completen.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```


## **FAQ**

**¿Necesito llamar a la configuración de licencia en cada hilo?**

No. Basta con hacerlo una vez por proceso/dominio de aplicación antes de que los hilos comiencen. Si la [configuración de licencia](/slides/es/nodejs-java/licensing/) pudiera invocarse concurrentemente (por ejemplo, durante una inicialización perezosa), sincronice esa llamada porque el método de configuración de licencia en sí no es seguro para hilos.

**¿Puedo pasar objetos `Presentation` o `Slide` entre hilos?**

No se recomienda pasar objetos de presentación “vivos” entre hilos: use instancias independientes por hilo o pre‑cree presentaciones/contendedores de diapositivas separados para cada hilo. Este enfoque sigue la recomendación general de no compartir una única instancia de presentación entre hilos.

**¿Es seguro paralelizar la exportación a diferentes formatos (PDF, HTML, imágenes) siempre que cada hilo tenga su propia instancia de `Presentation`?**

Sí. Con instancias independientes y rutas de salida separadas, esas tareas generalmente se paralelizan correctamente; evite cualquier objeto de presentación compartido y flujos de E/S compartidos.

**¿Qué debo hacer con la configuración global de fuentes (carpetas, sustituciones) en un entorno multihilo?**

Inicialice toda la configuración global de fuentes antes de iniciar los hilos y no la cambie durante el trabajo paralelo. Esto elimina las condiciones de carrera al acceder a recursos de fuentes compartidos.