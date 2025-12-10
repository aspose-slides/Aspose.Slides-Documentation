---
title: Integrando Aspose.Slides con Google Slides
linktitle: Google Slides
type: docs
weight: 50
url: /es/net/integrating-aspose-slides-with-google-slides/
keywords:
- plataformas en la nube
- integración en la nube
- Google Slides
- Google Drive
- API de Google
- Cuenta de servicio de Google
- integración SaaS
- OAuth 2.0
- PPT a PDF
- automatización de PowerPoint
- procesamiento de presentaciones
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Conectar Aspose.Slides con Google Slides para importar, sincronizar y convertir presentaciones, automatizar flujos de trabajo y mantener PowerPoint y OpenDocument en una única canalización."
---

## **Introducción**

Aspose.Slides ahora proporciona integración con Google Slides y Google Drive a través de su [SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations). Esta integración permite a las aplicaciones .NET convertir, editar, descargar y cargar presentaciones de Google Slides.

## **¿Qué es Google Slides?**

[Google Slides](https://workspace.google.com/products/slides/) es un software de presentación gratuito y basado en la web desarrollado por Google. Permite a los usuarios crear, editar y compartir presentaciones de diapositivas en línea, similar a Microsoft PowerPoint. Soporta colaboración en tiempo real, almacenamiento en la nube y funciona en cualquier dispositivo con acceso a Internet.

## **Google API**

Antes de comenzar a trabajar con su presentación de Google Slides mediante Aspose.Slides, debe crear un proyecto Google API y crear un [Google Cloud project](https://developers.google.com/workspace/guides/create-project), luego habilitar las API deseadas. 

Luego debe elegir la forma en que accederá a Google API: [Aspose.SlideS Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) admite dos maneras de acceder a Google API:
- `Google Service Account`
- `OAuth 2.0` con interacción del usuario a través de un navegador.

### **Google Service Account**

Una cuenta de servicio es una cuenta de Google especial utilizada por aplicaciones o servidores para acceder a las APIs de Google de forma programática sin interacción del usuario. Se utiliza comúnmente para sistemas backend o tareas automatizadas. Las cuentas de servicio se autentican mediante un archivo de clave JSON y tienen su propia dirección de correo electrónico. Se les pueden asignar permisos específicos a través de [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) y a menudo se usan con APIs como Google Drive, Sheets o BigQuery para acceso seguro y automatizado a recursos.

### **OAuth 2.0**

Otra forma común de acceder a las APIs de Google es mediante OAuth 2.0 con interacción del usuario a través de un navegador. En este flujo, el usuario es redirigido a una página de inicio de sesión de Google donde concede permiso a la aplicación. Después de la aprobación, la aplicación recibe un código de autorización, que intercambia por un token de acceso y un token de actualización.

El token de acceso permite acceso temporal a las APIs de Google, mientras que el token de actualización puede almacenarse y reutilizarse para obtener nuevos tokens de acceso sin que el usuario tenga que iniciar sesión nuevamente. Esto significa que la interacción del navegador es necesaria solo una vez, haciendo que el acceso posterior a la API sea totalmente automatizado. Este método se utiliza típicamente para aplicaciones que necesitan acceder a los datos de un usuario (como Gmail, Calendar o Drive) con el consentimiento del usuario.

## **Vamos a programar**

Primero, agregue el [Aspose.Slides SaaS Integration NuGet package](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) a su proyecto:
```
dotnet add package Aspose.Slides.SaaSIntegrations
```


### **Ejemplo 1**

En el siguiente ejemplo, descargaremos una presentación de Google Slides desde Google Drive y la guardaremos en el disco local como un archivo PDF. Utilizaremos una Google Service Account para la autorización, asumiendo que el archivo JSON de la cuenta de servicio con credenciales ya ha sido descargado.
```csharp
// Crear HttpClient gestionado externamente
HttpClient httpClient = new HttpClient();

// Crear un proveedor de autorización usando un archivo JSON de cuenta de servicio
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// Inicializar el servicio de integración de Google Slides con el proveedor de autorización
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Cargar una presentación de Google Drive por su ID de archivo en una instancia de IPresentation de Aspose.Slides
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// Modificar la presentación si es necesario (p.ej., eliminar la segunda diapositiva)
pres.Slides.RemoveAt(1);

// Guardar la presentación localmente como archivo PDF
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```


Para mayor comodidad, Aspose.Slides SaaS Integration proporciona un método para listar todos los archivos disponibles para el usuario. Los datos devueltos incluyen el nombre del archivo, el tipo MIME y el ID del archivo.
```csharp
// Obtener la lista de archivos disponibles para la cuenta de servicio proporcionada
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```


Otra forma de encontrar el ID del archivo es abrir la presentación en la aplicación web de Google Slides y localizarlo en la URL.

Por ejemplo, en la siguiente URL:
```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```


El ID del archivo es:
```
1A2B3C4D5E6F7G8H9I0J
```


## **Ejemplo 2**

En el próximo ejemplo, crearemos una presentación de PowerPoint desde cero y la cargaremos a Google Drive en formato Google Slides. Para la autorización, utilizaremos OAuth 2.0.
```csharp
// Crear HttpClient gestionado externamente
HttpClient httpClient = new HttpClient();

// Crear un proveedor de autorización usando OAuth con ID de cliente y secreto de cliente
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// Inicializar el servicio de integración de Google Slides con el proveedor de autorización
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Crear una presentación de ejemplo
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // Guardar la presentación en la carpeta raíz de Google Drive en formato Google Slides
    // También puede elegir cualquier otro formato de exportación soportado por Aspose.Slides
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```


Si usa este tipo de autorización en su aplicación, `interaction with the browser is required`. Necesitará seleccionar su cuenta y confirmar que permite que la aplicación acceda a su API de Google Drive. Eso es todo—esta operación solo se requiere en la primera ejecución.

### **Ejemplo 3**

En el siguiente ejemplo utilizaremos un token de acceso preobtenido. `GoogleAccessTokenAuthProvider` es una implementación de la interfaz `IGoogleAuthorizationProvider` que usa un token de acceso OAuth 2.0 existente para autorizar solicitudes a las APIs de Google. A diferencia de los proveedores que inician o gestionan el flujo OAuth, esta clase depende de que el llamador proporcione un token de acceso válido.

Este proveedor es útil en sistemas donde el token de acceso se obtiene externamente—típicamente por una aplicación frontend u otro servicio—y se pasa al backend. Es especialmente adecuado para entornos distribuidos donde gestionar tokens de actualización del lado del servidor introduce complejidad o riesgo de invalidación del token debido a intentos concurrentes de actualización.

Este ejemplo muestra cómo reemplazar un archivo y actualizar su nombre en Google Drive mientras se conserva su ID de archivo.
```csharp
// Crear un cliente HTTP para realizar solicitudes
using HttpClient httpClient = new HttpClient();

// Configurar la autenticación de Google Drive usando un token de acceso
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// Inicializar la integración con Google Slides/Drive usando la autenticación y el cliente HTTP
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Crear una presentación de ejemplo usando Aspose.Slides
using (var presentation = new Presentation())
{
    // Añadir una forma rectangular a la primera diapositiva y establecer su texto
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // Definir opciones de guardado PDF con calidad y cumplimiento específicos
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // Guardar (reemplazar) el archivo existente en Google Drive por ID, actualizar su nombre y exportar como PDF
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // ID del archivo existente en Google Drive
        GoogleSaveFormatType.Pdf,         // Formato deseado para guardar
        saveOptions,           
        "NewFileName.pdf"                 // Nuevo nombre a asignar al archivo
    );
}
```


## **Resumen**

Aspose.Slides ahora admite un formato de archivo adicional para la gestión, simplificando la automatización de flujos de trabajo basados en la nube para crear, compartir y editar presentaciones.

Este artículo cubrió las funciones básicas. También puede guardar archivos en subcarpetas, reemplazar archivos existentes y exportar a Google Drive en varios formatos—no limitados a presentaciones de Google Slides.

Aspose.Slides SaaS Integration continuará ampliando la compatibilidad con plataformas SaaS de presentaciones, así que vuelva para futuras actualizaciones.

## **Preguntas frecuentes**

**¿Necesito una cuenta de Google Workspace para usar esta integración?**  
No. Puede usar una cuenta de Google gratuita o una cuenta de Google Workspace. El acceso requerido depende de los permisos de su Google Drive y Slides.

**¿Qué método de autenticación debo elegir—Service Account o OAuth 2.0?**  
Use una **Service Account** para flujos de trabajo backend o automatizados sin interacción del usuario.  
Use **OAuth 2.0** si necesita acceder a los archivos de Google Slides o Drive de un usuario específico con su consentimiento.

**¿Puedo trabajar con formatos diferentes a Google Slides?**  
Sí. Aspose.Slides permite guardar presentaciones en varios formatos (p. ej., PDF, PPTX, HTML) antes de cargarlos a Google Drive.

**¿Cómo puedo obtener el ID de archivo de una presentación de Google Slides?**  
Puede obtenerlo usando el método `GetDriveFileInfosAsync()` o copiándolo de la URL de la presentación en Google Slides.

**¿La integración admite reemplazar un archivo existente en Google Drive?**  
Sí. Use el método `SavePresentationToExistingFileAsync` para actualizar un archivo mientras conserva su ID de archivo.

**¿Se requiere interacción del navegador cada vez al usar OAuth 2.0?**  
No. La interacción del navegador solo es necesaria durante la primera autorización. Después de eso, los tokens de actualización almacenados permiten el acceso automatizado.