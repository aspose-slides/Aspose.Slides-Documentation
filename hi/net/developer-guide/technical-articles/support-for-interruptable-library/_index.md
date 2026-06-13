---
title: Interruptable लाइब्रेरी के लिए समर्थन
type: docs
weight: 150
url: /hi/net/support-for-interruptable-library/
keywords:
- interruptable लाइब्रेरी
- interruption टोकन
- cancellation टोकन
- लंबी अवधि का कार्य
- बाधित कार्य
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides के साथ लंबी अवधि के कार्यों को रद्द करने योग्य बनाएं। PowerPoint और OpenDocument के लिए रेंडरिंग और रूपांतरण को सुरक्षित रूप से बाधित करें, उदाहरणों के साथ."
---
## **अवलोकन**

Aspose.Slides for .NET लंबी अवधि के प्रेज़ेंटेशन कार्यों, जैसे कि डीसिरियलाइज़ेशन, सीरियलाइज़ेशन और रेंडरिंग, के लिए एक इंटर्रप्टेबल प्रोसेसिंग मैकेनिज्म प्रदान करता है। यह मैकेनिज्म `InterruptionToken` और `InterruptionTokenSource` क्लासों पर आधारित है।

`InterruptionToken` को `LoadOptions` को असाइन किया जा सकता है और `Presentation` कन्स्ट्रक्टर को पास किया जा सकता है। जब `InterruptionTokenSource.Interrupt()` को कॉल किया जाता है, तो संबंधित लंबी अवधि का कार्य बाधित हो जाता है। यह लेख यह भी दर्शाता है कि इस मैकेनिज्म को मानक .NET `CancellationToken` के साथ कैसे उपयोग किया जाए, जिससे रद्दीकरण अनुरोधों की निगरानी की जा सके और रद्दीकरण का अनुरोध होने पर `Interrupt()` को कॉल किया जाए।

## **इंटर्रप्टेबल लाइब्रेरी**

In [Aspose.Slides 18.4](https://releases.aspose.com/slides/hi/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/), we introduced the [InterruptionToken](https://reference.aspose.com/slides/hi/net/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/hi/net/aspose.slides/interruptiontokensource/) classes. They allow you to interrupt long-running tasks such as deserialization, serialization, and rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/hi/net/aspose.slides/interruptiontokensource/) टोकन(स) का स्रोत है जो [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/hi/net/aspose.slides/iloadoptions/interruptiontoken/) को पास किया जाता है।
- जब [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/hi/net/aspose.slides/iloadoptions/interruptiontoken/) सेट किया जाता है और [LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) की इंस्टेंस को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) कन्स्ट्रक्टर में पास किया जाता है, तो [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/hi/net/aspose.slides/interruptiontokensource/interrupt/) को कॉल करने से उस [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) से जुड़ा कोई भी लंबा कार्य बाधित हो जाता है।

निम्नलिखित कोड स्निपेट चल रहे कार्य को बाधित करने का प्रदर्शन करता है:

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // एक अलग थ्रेड में क्रिया चलाएँ
    Thread.Sleep(10000);            // समय समाप्ति
    tokenSource.Interrupt();        // रूपांतरण रोकें
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **.NET CancellationToken और इंटर्रप्टेबल लाइब्रेरी**

When you need to use a [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) alongside the Aspose.Slides Interruptible library, wrap the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) processing and interrupt the [InterruptionToken](https://reference.aspose.com/slides/hi/net/aspose.slides/interruptiontoken/) when [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) is `true`.

यह C# कोड इस कार्य को दर्शाता है:

```cs
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // एक अलग थ्रेड में क्रिया चलाएँ

    while (!task.Wait(500)) // रुकें और मॉनिटर करें कि cancellationToken.IsCancellationRequested सेट है या नहीं
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // Presentation प्रोसेसिंग को बाधित करें
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides इंटर्रप्ट लाइब्रेरी का उद्देश्य क्या है?**

यह लंबी अवधि के ऑपरेशनों—जैसे कि प्रेज़ेंटेशन को लोड करना, सेव करना, या रेंडर करना—को समाप्त होने से पहले बाधित करने का मैकेनिज्म प्रदान करता है। यह तब उपयोगी होता है जब प्रोसेसिंग समय सीमित होना चाहिए या कार्य अब आवश्यक नहीं रहता।

**[InterruptionToken](https://reference.aspose.com/slides/hi/net/aspose.slides/interruptiontoken/) और [InterruptionTokenSource](https://reference.aspose.com/slides/hi/net/aspose.slides/iinterruptiontokensource/) में क्या अंतर है?**

- `InterruptionToken` को Aspose.Slides API को पास किया जाता है और लंबी अवधि के ऑपरेशनों के दौरान जाँचा जाता है।
- `InterruptionTokenSource` का उपयोग आपके कोड में टोकन बनाने और `Interrupt()` को कॉल करके बाधित करने के लिए किया जाता है।

**क्या मैं .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) को इंटर्रप्ट लाइब्रेरी के साथ उपयोग कर सकता हूँ?**

हां। आप अपने एप्लिकेशन लॉजिक में [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) की निगरानी कर सकते हैं और रद्दीकरण के अनुरोध पर [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/hi/net/aspose.slides/iinterruptiontokensource/interrupt/) को कॉल कर सकते हैं। यह Aspose.Slides को मानक .NET रद्दीकरण वर्कफ़्लो के साथ एकीकृत करने में सक्षम बनाता है।

**क्या कार्य बाधित किए जा सकते हैं?**

कोई भी Aspose.Slides कार्य जो [InterruptionToken](https://reference.aspose.com/slides/hi/net/aspose.slides/interruptiontoken/) स्वीकार करता है—जैसे `Presentation(path, loadOptions)` से प्रेज़ेंटेशन लोड करना या `Presentation.Save(...)` से सेव करना—को बाधित किया जा सकता है।

**क्या बाधित करना तुरंत होता है?**

नहीं। बाधित करना सहयोगात्मक होता है: ऑपरेशन नियमित रूप से टोकन को जाँचता है और जैसे ही यह पहचानता है कि [Interrupt()](https://reference.aspose.com/slides/hi/net/aspose.slides/iinterruptiontokensource/interrupt/) को कॉल किया गया है, रोक देता है।

**यदि मैं किसी कार्य के पूरा होने के बाद [Interrupt()](https://reference.aspose.com/slides/hi/net/aspose.slides/iinterruptiontokensource/interrupt/) को कॉल करता हूँ तो क्या होता है?**

कुछ नहीं—यदि संबंधित कार्य पहले ही पूरा हो चुका है, तो कॉल का कोई प्रभाव नहीं रहता।

**क्या मैं कई कार्यों के लिए एक ही [InterruptionTokenSource](https://reference.aspose.com/slides/hi/net/aspose.slides/iinterruptiontokensource/) का पुन: उपयोग कर सकता हूँ?**

हां—लेकिन जब आप उस स्रोत पर [Interrupt()](https://reference.aspose.com/slides/hi/net/aspose.slides/iinterruptiontokensource/interrupt/) को कॉल करते हैं, तो उसके टोकन का उपयोग करने वाले सभी कार्य बाधित हो जाएंगे। कार्यों को स्वतंत्र रूप से प्रबंधित करने के लिए अलग-अलग टोकन स्रोतों का उपयोग करें।