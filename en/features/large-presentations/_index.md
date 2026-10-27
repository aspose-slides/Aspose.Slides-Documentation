---
title: Work with large presentations
description: Process large presentations with memory and storage settings suited to their content.
type: docs
url: /features/large-presentations/
weight: 1590
feature_id: large-presentations
feature_group: runtime
translationKey: slides-feature-large-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/manage-blob/
---

## **Overview**

Use the installed library for large presentation files without a hosted upload-size limit. Capacity depends on the document's structure and the resources available to the application. Media-management options can help when large embedded objects account for much of the file size.

## **Usage guidance**

Budget for the expanded document model, embedded media, output buffers and concurrent jobs. Choose a representative presentation and measure the actual workflow before increasing worker count. For executable controls, see [Memory management](/slides/features/memory-management/) and [Stream large media](/slides/features/stream-media/). A single file-size threshold cannot establish a universal safe limit.

## **FAQ**

### **Can file size alone predict the memory needed?**

No. A small file with many slides and shapes can have a large document model, while a media-heavy file may benefit from BLOB-management settings.

### **How can temporary-storage capacity affect a large-media workflow?**

When BLOB settings allow disk storage, the temporary volume needs space for the media and any concurrent work. Use a writable location with enough capacity, and dispose presentations so their temporary resources can be released. A large disk does not remove the memory needed by the document model.

### **How should I budget concurrency when processing large decks?**

Measure peak memory and temporary-disk use with representative decks, then choose a bounded worker count that fits the host. Give workers separate presentation instances and unique outputs; adding CPU threads alone does not make more memory available.

## **Guides**

- [Manage Presentation BLOBs in .NET for Efficient Memory Use](/slides/net/manage-blob/)

Related feature: [Control memory used by embedded media](/slides/features/memory-management/).
