---
title: Licensing
type: docs
weight: 90
url: /androidjava/licensing/
keywords:
- license
- temporary license
- set license
- use license
- validate license
- license file
- evaluation version
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Apply, manage, and troubleshoot licenses in Aspose.Slides for Android via Java. Ensure uninterrupted access to full features with our licensing guide."
---

## **Overview**

Aspose.Slides can be used in evaluation mode or with a valid license. The evaluation version provides the same functionality as the licensed version, but it adds an evaluation watermark to every slide of each presentation it saves and truncates text that your code reads from presentations.

This article explains how licensing works in Aspose.Slides and how to apply a license before using the library. A license can be loaded from a file, stream, or embedded resource by using the [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) class. The article also shows how to validate whether a license has been applied correctly.

## **Evaluate Aspose.Slides**

{{% alert color="info" title="Note" %}}

You can download an evaluation version of **Aspose.Slides for Android via Java** from its [download page](https://releases.aspose.com/slides/androidjava/). The evaluation version provides the same functionalities as the licensed version of the product. The evaluation package is the same as the purchased package. The evaluation version simply becomes licensed after you add a few lines of code to it (to apply the license).

Once you are happy with your evaluation of **Aspose.Slides**, you can [purchase a license](https://purchase.aspose.com/pricing/slides/android-java/). We recommend you go through the different subscription types. If you have questions, contact the Aspose sales team.

Every Aspose license comes with a one-year subscription for free upgrades to new versions or fixes released within the subscription period. Users with licensed products (or even evaluation versions) get free and unlimited technical support.

{{% /alert %}} 

**Evaluation version limitations**

* The evaluation version (without a license specified) provides full product functionality, but it adds an evaluation watermark text box to every slide of each presentation it saves.
* Text that your code reads from a presentation is truncated to its first few characters, followed by a notice about the evaluation limitation. Text that your code writes is saved in full.

{{% alert color="info" title="Note" %}}

To test Aspose.Slides without limitations, you can ask for a **30-Day Temporary License**. See the [How to get a Temporary License](https://purchase.aspose.com/temporary-license) page for more information.

{{% /alert %}}

## **Licensing in Aspose.Slides**

* An evaluation version becomes licensed after you purchase a license and add a couple of lines of code to it (to apply the license).
* The license is a plain-text XML file that contains details such as the product name, number of developers it is licensed to, subscription expiry date, and so on. 
* The license file is digitally signed, so you must not modify the file. Even an inadvertent addition of an extra line break to the contents of the file will invalidate it.
* Aspose.Slides for Android via Java typically tries to find the license in these locations:
  * An explicit path
  * The folder containing Aspose.Slides.jar
* To avoid the limitations associated with the evaluation version, you need to set a license before using **Aspose.Slides**. You only have to set a license once per application or process.

## **Applying a License**

A license can be loaded from a **file** or **stream**.

{{% alert color="info" title="Note" %}}

Aspose.Slides provides the [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) class for licensing operations.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

New licenses can activate Aspose.Slides only with version 21.4 or later. Earlier versions use a different licensing system and will not recognize these licenses.

{{% /alert %}}

### **File**

The easiest method of setting a license requires you to place the license file in the folder containing Aspose.Slides.jar or your application's jar.

{{% alert color="info" title="Note" %}}

On Android, the library and your app are packaged into the APK, so there is no folder that contains the library's JAR file, and a relative path such as *Aspose.Slides.Android.via.Java.lic* does not point to a file in your app. Add the license file to your app's assets and load it from a stream, as shown in [Stream from App Assets](#stream-from-app-assets).

{{% /alert %}}

This Java code shows you how to set a license file:

``` java
// Instantiates the License class
com.aspose.slides.License license = new com.aspose.slides.License();

// Sets the license file path
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

If you place the license file in a different directory, when you call the [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) method, the license file name at the end of the specified path must be the same as your license file name.

For example, you can change the license file name to *Aspose.Slides.Android.via.Java.lic.xml*. Then, in your code, you have to pass the path to the file (ending with *Aspose.Slides.Android.via.Java.lic.xml*) to the [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) method.

{{% /alert %}}

### **Stream**

You can load a license from a stream. This Java code shows you how to apply a license from a stream:

``` java
// Instantiates the License class
com.aspose.slides.License license = new com.aspose.slides.License();

// Sets the license through a stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Stream from App Assets**

In an Android app, put the license file in the *assets* folder of the app module, *app/src/main/assets*, so that it is packaged into the APK. Open the file with the [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) method and pass the stream to the [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) method. The code runs inside an `Activity`, for example in its `onCreate` method, before the app uses Aspose.Slides:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

The file name passed to the [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) method is relative to the *assets* folder. If the file is not there, the code logs the error, and Aspose.Slides stays in evaluation mode. To check whether the license was applied, see [Validating a License](#validating-a-license).

## **Validating a License**

To check whether a license has been set properly, you can validate it. This Java code shows you how to validate a license:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Thread Safety**

{{% alert color="warning" title="Warning" %}}

The [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) method is not thread-safe. If this method has to be called simultaneously from many threads, you may want to use synchronization primitives (like a lock) to avoid issues.

{{% /alert %}}

## **FAQ**

### Can I apply the license in a completely offline environment (no internet access)?

Yes. License validation is performed locally using the license file; no internet connection is required.

### What happens after the one-year subscription expires? Will the library stop working?

No. The license is perpetual: you can continue using versions released before your subscription end date; you just won’t be eligible to use newer releases without renewing.
