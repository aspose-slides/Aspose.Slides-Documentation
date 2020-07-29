---
title: Support For Interruptable Library
type: docs
weight: 150
url: /net/support-for-interruptable-library/
---

### **Interruptable Library**
Now in Aspose.Slides InterruptionToken struct and InterruptionTokenSource class have been added. These types support interruption of long-running tasks, such as deserialization, serialization or rendering. InterruptionTokenSource represents the source of the token or multiple tokens passed to **ILoadOptions.InterruptionToken**. When ILoadOptions.InterruptionToken is set and this LoadOptions instance passed to the Presentation constructor, any long-running task related to this Presentation will be interrupted when InterruptionTokenSource.Interrupt method will be invoked.

Code snippet below demonstrates interruption of running task.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-Presentations-Properties-SupportForInterrupt-SupportForInterrupt.cs" >}}
